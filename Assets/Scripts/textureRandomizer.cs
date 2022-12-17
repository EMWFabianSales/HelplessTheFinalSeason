using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureRandomizer : MonoBehaviour
{   
    public enum itemType {paper, book};
    public itemType Item;
    // Start is called before the first frame update
    void Start()
    {   
        List<Texture2D> objTextures = new List<Texture2D>();
        if(Item == itemType.paper){
            objTextures = gameManager.instance.paperTextures;
        }else if(Item == itemType.book){
            objTextures = gameManager.instance.bookTextures;
        }


        int texturetoparse = Random.Range(0, objTextures.Count - 1);
        GetComponent<MeshRenderer>().materials[0].SetTexture("_BaseColorMap", objTextures[texturetoparse]);
    }

    // Update is called once per framez
    void Update()
    {
        
    }
}
