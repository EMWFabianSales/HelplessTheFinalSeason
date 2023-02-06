using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStandInScript : MonoBehaviour
{
    public static playerStandInScript instance;

    void Awake() {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        yourMumsADudeAndPleaseMovePositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void yourMumsADudeAndPleaseMovePositions(){
        transform.position = new Vector3(
            Random.Range(-20,20),
            1,
            Random.Range(-20,20)
        );
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
