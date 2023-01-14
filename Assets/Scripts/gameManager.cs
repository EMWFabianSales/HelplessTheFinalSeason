using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public Material OutlineMat;
    public Object[] paperTextures;
    public Object[] bookTextures;
    //Procedural Clutter Gen Settings
    //list of Medical Paper Prefabs
    public List<GameObject> procMedPaperGenPrefabs = new List<GameObject>();
    //list of Book Prefabs
    public List<GameObject> procBookGenPrefabs = new List<GameObject>();
    //list of Medical object prefabs
    public List<GameObject> procMedGenPrefabs = new List<GameObject>();
    //list of Rouble Prefabs
    public List<GameObject> procRoubleGenPrefabs = new List<GameObject>();
    //list of Litter Prefabs
    public List<GameObject> procLitterGenPrefabs = new List<GameObject>();
    //list of serialized Generation Areas
    public List<proceduralGenerationGroup> procGenGroups = new List<proceduralGenerationGroup>();
    //list of Group Gen Objects
    private List<GameObject> procGenGroupObjs = new List<GameObject>();

    // Start is called before the first frame update
    void Awake() {
        //Serializes all Paper and Book Textures from Resources/Textures
        paperTextures = Resources.LoadAll("Textures/medicalPapers", typeof(Texture2D));
        bookTextures = Resources.LoadAll("Textures/bookCovers", typeof(Texture2D));   
    }

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

        int phase = 0;
        //loops through and itterates through generation Passes
        while (phase <= 4)
        {
            ItemGenerator(phase);
            phase++;
        }
    }

    //itemGenerator
    public void ItemGenerator(int pass){
        List<GameObject> prefabpool = null;
        int items = 0;

        //loop for second generation pass (Books)
        foreach (var group in procGenGroups)
        {

            //selects proper prefab pool based on which pass is currently executed, as well as amount of items to generate for specific pass
            switch(pass){
                //First Pass (Medical Supplies)
                case 0:
                    prefabpool = procMedGenPrefabs;
                    items = group.medicalPiles;
                    break;
                //Second Pass (Books)
                case 1:
                    prefabpool = procBookGenPrefabs;
                    items = group.bookPiles;
                    break;
                //Third Pass (Medical Papers)
                case 2:
                    prefabpool = procMedPaperGenPrefabs;
                    items = group.paperPiles;
                    break;
                //Fourth Pass (Rouble)
                case 3:
                    prefabpool = procRoubleGenPrefabs;
                    items = group.roublePiles;
                    break;
                //5th Pass (Litter)
                case 4:
                    prefabpool = procLitterGenPrefabs;
                    items = group.litterPiles;
                    break;
            }

            for (int i = 0; i < items; i++)
            {
                //instanciates prefab at center of Group Object
                GameObject generatedItem = Instantiate(prefabpool[Random.Range(0, prefabpool.Count)], group.GroupPosition, Quaternion.Euler(0,0,0),procGenGroupObjs[procGenGroups.IndexOf(group)].transform);
                //adds instance to group's object list
                group.GeneratedItems.Add(generatedItem);
                //sets position of object Instance randomly, relative to center of group object
                generatedItem.transform.Translate(new Vector3(
                    Random.Range(-group.groupArea/2f,group.groupArea/2f),
                    0f,
                    Random.Range(-group.groupArea/2f,group.groupArea/2f)
                ));
                 //sets random Rotation for object
                generatedItem.transform.rotation = Quaternion.Euler(
                    0,
                    Random.Range(0,360),
                    0
                );
            }   
        }
    }

    //Interactions parser
    public void InteractionHandler(GameObject InteractionObject){
        InteractionObject.GetComponent<PlayerInteractableScript>().onPlayerInteraction();
    }

    void OnDrawGizmos()
    {
        foreach (var group in procGenGroups)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(group.GroupPosition, new Vector3(group.groupArea, .25f, group.groupArea));
            UnityEditor.Handles.Label(group.GroupPosition + transform.forward * (group.groupArea/2), $"Group {procGenGroups.IndexOf(group)}");
            UnityEditor.Handles.Label(group.GroupPosition + transform.forward * (group.groupArea/4), $"Medical Items: {group.medicalPiles.ToString()}");
            UnityEditor.Handles.Label(group.GroupPosition + transform.forward * (group.groupArea/8), $"Books: {group.bookPiles.ToString()}");
            UnityEditor.Handles.Label(group.GroupPosition, $"Papers: {group.paperPiles.ToString()}");
            UnityEditor.Handles.Label(group.GroupPosition + transform.forward * (-group.groupArea/8), $"Rouble: {group.roublePiles.ToString()}");
            UnityEditor.Handles.Label(group.GroupPosition + transform.forward * (-group.groupArea/4), $"Litter Items: {group.litterPiles.ToString()}");
        }
    }
}

