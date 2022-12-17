using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableScript : MonoBehaviour
{
    public enum InteractionType {Item, Door};
    public InteractionType ObjectInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayerInteraction(){
        if (ObjectInteraction == InteractionType.Item){
            Destroy(gameObject);
        }
    }
}
