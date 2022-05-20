using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class PlantObject : ScriptableObject
{
    public string plantName;
    public Sprite[] plantStages;
    //public Sprite icon;

    public float generateRandom()
    {
        System.Random rand = new System.Random();
        double min = 1;
        double max = 10;
        double range = max - min;

        double sample = rand.NextDouble();
        double scaled = (sample * range) + min;
        float f = (float)scaled;
        Debug.Log(f);
        return f;

    }
}
