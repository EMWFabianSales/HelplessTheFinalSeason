using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour
{
    Rigidbody rb;
    public Vector2 raw_movement_vector;
    public float walk_speed;
    public float run_speed;
    public float current_speed;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move_player();
    }

    public void move_player(){
        Vector2 calculatedMovement = raw_movement_vector * walk_speed;
        //calculatedMovement = Vector2.ClampMagnitude(calculatedMovement, walk_speed);
        rb.AddForce(new Vector3(calculatedMovement.x, 0, calculatedMovement.y));
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10f);
    }

    public void getRawMovementVectors(InputAction.CallbackContext ctx){
        raw_movement_vector = ctx.ReadValue<Vector2>();
    }
}
