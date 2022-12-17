using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralClutter : MonoBehaviour
{
    public LayerMask clutterLayer;
    public float clutterRange;
    public int clutterPiles;
    public float spread;
    public int attemptThreshhold;
    public GameObject[] clutterPrefabs;
    public List<GameObject> clutterObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < clutterPiles; i++)
        {
            int randomPile = Random.Range(0, clutterPrefabs.Length);
            bool positionValid = false;
            GameObject generatedClutter = Instantiate(clutterPrefabs[randomPile], transform);
            
            clutterObjects.Add(generatedClutter);

            int attempts = 0;
            while (!positionValid)
            {   
                Vector3 randpos = new Vector3(
                Random.Range(-clutterRange/2, clutterRange/2),
                Random.Range(0f, 0.01f),
                Random.Range(-clutterRange/2, clutterRange/2)
                );
                float randRot = Random.Range(0,360);
                generatedClutter.transform.position = randpos;
                generatedClutter.transform.rotation = Quaternion.Euler(0, randRot,0);
                RaycastHit hit;
                if (Physics.Raycast(generatedClutter.transform.position, Vector3.down, out hit, 0.1f, clutterLayer))
                {
                    if(clutterObjects.Count < 2){
                        positionValid = true;
                    }else{
                        foreach (GameObject item in clutterObjects){
                            if(item != generatedClutter){
                                if(Vector3.Distance(item.transform.localPosition, generatedClutter.transform.localPosition) > spread){
                                    positionValid = true;
                                }
                            }
                        }
                    }
                }
                if(attempts > attemptThreshhold){
                    clutterObjects.Remove(generatedClutter);
                    Destroy(generatedClutter);
                    break;
                }
                attempts += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(clutterRange, 1f, clutterRange));
    }
}
