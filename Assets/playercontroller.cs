using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour
{
    public Transform playerCamera; 
    CharacterController charcon;
    public Vector2 raw_Mouse_Val;
    public float mouseSensitivity;
    float xRot;
    public Vector2 raw_movement_vector;
    public bool IsSprinting;

    public LayerMask InteractableLayer;

    public float walk_speed;
    public float run_speed;
    public float current_speed;

    void Awake(){
        charcon = GetComponent<CharacterController>();
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
        move_player();
        update_cameraRot();
        Raycast_check();
    }

    public void Raycast_check(){
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 5, InteractableLayer)){
            print(hit.transform.gameObject.name);
            Material[] hitMats = hit.transform.GetComponent<MeshRenderer>().materials;
            hitMats[hitMats.Length - 1].SetFloat("_Thickness", 1);
        }
    }

    public void update_cameraRot(){
        Vector2 mouseVal = raw_Mouse_Val * mouseSensitivity * Time.deltaTime;

        xRot -= mouseVal.y;
        xRot = Mathf.Clamp(xRot, -87f, 87f);
        playerCamera.localRotation =  Quaternion.Euler(xRot,0,0);
        
        transform.Rotate(Vector3.up * mouseVal.x);
    }

    public void move_player(){

        if (IsSprinting){
            current_speed = run_speed;
        }else{
            current_speed = walk_speed;
        }

        Vector3 calculatedMovement = (transform.forward * raw_movement_vector.y
        + transform.right * raw_movement_vector.x) * current_speed * Time.deltaTime;

        charcon.Move(calculatedMovement);
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

}
