using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public Material OutlineMat;
    public List<Texture2D> paperTextures = new List<Texture2D>();
    public List<Texture2D> bookTextures = new List<Texture2D>();
    public List<GameObject> procGenPrefabs = new List<GameObject>();
    public List<proceduralGenerationGroup> procGenGroups = new List<proceduralGenerationGroup>();
    private List<GameObject> procGenGroupObjs = new List<GameObject>();
    //procedural clutter settings
    /*public LayerMask clutterLayer;
    
    public GameObject[] clutterPrefabs;

    

    public float clutterRange;
    public int clutterPiles;
    public float spread;
    public int attemptThreshhold;
    public List<GameObject> clutterObjects = new List<GameObject>();
    */

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        generateClutter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //generate clutter
    public void generateClutter(){
        //loop for every item in procGenGroups List
        foreach (var group in procGenGroups)
        {
            //create a gameobject for item in list
            GameObject groupObject = new GameObject($"proc_Gen_Group_{procGenGroups.IndexOf(group)}");
            //set item's gameobject parent to Game Manager Object
            groupObject.transform.SetParent(transform);
            //adds group object to list of group objects
            procGenGroupObjs.Add(groupObject);
        }
        //loop for first generation pass (Medical supplies)
        foreach (var group in procGenGroups)
        {
            for (int i = 0; i < group.medicalPiles; i++)
            {
                //instanciates medical prefab at center of Group Object
                GameObject generatedMedItem = Instantiate(procGenPrefabs[0], group.GroupPosition, Quaternion.Euler(0,0,0),procGenGroupObjs[procGenGroups.IndexOf(group)].transform);
                //adds instance to group's Medical object list
                group.medicalObjects.Add(generatedMedItem);
                //sets position of medical object Instance randomly, relative to center of group object
                generatedMedItem.transform.Translate(new Vector3(
                    Random.Range(-group.groupArea/2f,group.groupArea/2f),
                    0f,
                    Random.Range(-group.groupArea/2f,group.groupArea/2f)
                ));
            }   
        }
    }
    //Interactions parser
    public void InteractionHandler(GameObject InteractionObject){
        InteractionObject.GetComponent<PlayerInteractableScript>().onPlayerInteraction();
    }

    //generate clutter
    /*public void generateClutter(){
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
                                    print(Vector3.Distance(item.transform.localPosition, generatedClutter.transform.localPosition));

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

    */
    void OnDrawGizmos()
    {
        foreach (var group in procGenGroups)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(group.GroupPosition, new Vector3(group.groupArea, .25f, group.groupArea));
        }
    }
}
