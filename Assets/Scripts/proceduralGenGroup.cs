using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class proceduralGenerationGroup
{
    public Vector3 GroupPosition;
    public float groupArea;
    
    //PaperPiles
    public int paperPiles;
    public List<GameObject> paperObjects = new List<GameObject>();
    //Book Piles
    public int bookPiles;
    public List<GameObject> bookObjects = new List<GameObject>();
    //Medical Supply Piles
    public int medicalPiles;
    [HideInInspector]
    public List<GameObject> medicalObjects = new List<GameObject>();
    //Collapsed Rouble Piles
    public int roublePiles;
    public List<GameObject> roubleObjects = new List<GameObject>();

}