using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour
{
    public Transform playerCamera; 
    CharacterController charcon;
    //Camera Settings
    Vector2 raw_Mouse_Val;
    [Space(10)]
    public float mouseSensitivity;
    float xRot;
    //camera bopping
    Vector3 newCameraPos;
    public float lerpTime;
    //Movement Settings
    Vector2 raw_movement_vector;
    [Space(10)]
    bool IsSprinting;
    public float walk_speed;
    public float run_speed;
    float current_speed;

    //gravity stuffs
    public Transform groundChecker;
    public float groundCheckRad;
    public LayerMask groundLayer;
    bool grounded;
    public float gravity;
    Vector3 gravVel;

    //raycast settings
    public LayerMask InteractableLayer;
    bool canInteract;
    GameObject rayCastSelectedItem = null;
    Material[] hitMats;


    void Awake(){
        charcon = GetComponent<CharacterController>();
        newCameraPos = playerCamera.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        move_player();
        //viewBobbing();
        update_cameraRot();
        Raycast_check();
    }

    public void GroundCheck(){
        //RaycastHit hit;
        //if(Physics.SphereCast(groundChecker, groundCheckRad, groundCheckRad, )){

        //}
    }

    public void Raycast_check(){
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5, InteractableLayer)){
            if (rayCastSelectedItem != hit.transform.gameObject){
                rayCastSelectedItem = hit.transform.gameObject;
            }
            hitMats = rayCastSelectedItem.GetComponent<MeshRenderer>().materials;
            hitMats[hitMats.Length - 1].SetFloat("_Thickness", .05f);
            canInteract = true;
        }else{
            if (hitMats != null){
            hitMats[hitMats.Length - 1].SetFloat("_Thickness", 0);
            hitMats = null;
            rayCastSelectedItem = null;
            canInteract = false;
            }
        }
    }

    public void update_cameraRot(){
        Vector2 mouseVal = raw_Mouse_Val * mouseSensitivity * Time.deltaTime;

        xRot -= mouseVal.y;
        xRot = Mathf.Clamp(xRot, -87f, 87f);
        playerCamera.localRotation =  Quaternion.Euler(xRot,0,0);
        
        transform.Rotate(Vector3.up * mouseVal.x);
    }

    public void viewBobbing(){
        float viewbobheight = 0;

        if(charcon.velocity.magnitude > 0.01 && !IsSprinting){
            if(playerCamera.position.y == newCameraPos.y){
                viewbobheight = Random.Range(0.25f,0.75f);
                newCameraPos = new Vector3(transform.position.x, transform.position.y + viewbobheight, transform.position.z);
            }
        }else{
            newCameraPos = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
        }

        playerCamera.position = Vector3.Lerp(playerCamera.position, newCameraPos, lerpTime * Time.deltaTime);

    }

    public void move_player(){

        if (grounded){
            gravVel.y = -2;
        }
        
        if (IsSprinting){
            current_speed = run_speed;
        }else{
            current_speed = walk_speed;
        }

        Vector3 calculatedMovement = (transform.forward * raw_movement_vector.y
        + transform.right * raw_movement_vector.x) * current_speed * Time.deltaTime;

        charcon.Move(calculatedMovement);

        gravVel.y -= gravity * Time.deltaTime;

        charcon.Move(gravVel * Time.deltaTime);
    }

    public void getRawMovementVectors(InputAction.CallbackContext ctx){
        raw_movement_vector = ctx.ReadValue<Vector2>();
    }

    public void getSprintVal(InputAction.CallbackContext ctx){
        if(ctx.performed){
            IsSprinting = true;
        }
        else if(ctx.canceled){
            IsSprinting = false;
        }
    }

    public void getRawMouseVal(InputAction.CallbackContext ctx){
        raw_Mouse_Val = ctx.ReadValue<Vector2>();
    }

    public void InteractionSend(InputAction.CallbackContext ctx){
        if(canInteract && ctx.started){
            
        }
    }
}
