using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class proceduralGenerationGroup
{
    //Group Area Position
    public Vector3 GroupPosition;
    //Generation Area
    public float groupArea;
    //Attempts for Position Validation
    public int generationAttempts;
    //Distance from another object for generated item to be valid
    public float validDistance;
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