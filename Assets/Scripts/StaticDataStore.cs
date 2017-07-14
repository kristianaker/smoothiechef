using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class StaticDataStore {

    // THIS CLASS KEEPS TRACK OF LEVELS THAT ARE PLAYED, AND IF IT'S A RETRY. STORE TO SAVEFILE FROM CUSTOMER CLASS.
    
    // Keep track of level played.
    public float[] levelScore = new float[30];

    public int levelsPlayed;

    public bool isThisRetry;
}
