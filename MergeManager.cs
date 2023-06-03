using System.Collections.Generic;
using UnityEngine;


public class MergeManager : MonoBehaviour
{
    public List<MergeMelee> mergeMelee;
    public List<MergeRange> mergeRange;


    public int GetMelee(int mergeID)
    {
        return mergeMelee.FindIndex(x => x.mergeID == mergeID);
    }

    public int GetRange(int mergeID)
    {
        return mergeRange.FindIndex(x => x.mergeID == mergeID);
    }

    public int GetMaxMergeID()
    {
        return mergeMelee.Count;
    }
}


[System.Serializable]
public class MergeMelee
{
    public int mergeID;
    public float damage;
    public int health;
    public MeleeType meleeType;
    public GameObject characterPrefab;
}

[System.Serializable]
public class MergeRange
{
    public int mergeID;
    public float damage;
    public int health;
    public GameObject characterPrefab;
    public GameObject arrowPrefab;
}

[System.Serializable]
public enum MeleeType
{
    oneHanded,
    twoHanded,
    twinBlades
}