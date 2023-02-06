using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class killerAI : MonoBehaviour
{
    public GameObject playerTarget;
    public NavMeshAgent agent;
    public Vector3 targetPos;
    //AI Condition Variables
    public float sightRange;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {  
        agent = GetComponent<NavMeshAgent>();
        playerTarget = playerStandInScript.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.destination != playerTarget.transform.position){            
            agent.SetDestination(playerTarget.transform.position);
        }
        if(Vector3.Distance(transform.position, playerTarget.transform.position) < 5f){
            playerTarget.GetComponent<playerStandInScript>().yourMumsADudeAndPleaseMovePositions();
        }
        
    }

    private Vector3 DirectionFromAngle(float EulerY, float angleInDegrees)
    {
        angleInDegrees += EulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos() {
        Vector3 viewAngle01 = DirectionFromAngle(transform.eulerAngles.y, -angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(transform.eulerAngles.y, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward + viewAngle01 * sightRange);
        Gizmos.DrawLine(transform.position, transform.forward + viewAngle02 * sightRange);

    }
}
