using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
    [CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
    public class PlantObject : ScriptableObject
    {
        public string plantName;
        public Sprite[] plantStages;

        private readonly int buyPrice = 10;
        private readonly int sellPrice = 15;

        public float GenerateRandom()
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

        public int GetBuyPrice()
        {
            return buyPrice;
        }

        public int GetSellPrice()
        {
            return sellPrice;
        }

    }

}