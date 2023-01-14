using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class proceduralGenerationGroup
{
    public Vector3 GroupPosition;
    public float groupArea;
    [Space(200f)]
    //PaperPiles
    public int paperPiles;
    //Book Piles
    public int bookPiles;
    //Medical Supply Piles
    public int medicalPiles;
    //Collapsed Rouble Piles
    public int roublePiles;
    //other litter
    public int litterPiles;
    public List<GameObject> GeneratedItems = new List<GameObject>();

}