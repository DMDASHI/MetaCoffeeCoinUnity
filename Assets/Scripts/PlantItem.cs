using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class PlantItem : MonoBehaviour
    {
        public PlantObject plant;

        FarmManager farm;
        public Image btnImage;
        public Text btnTxt;

        // Start is called before the first frame update
        void Start()
        {
            farm = FindObjectOfType<FarmManager>();
        }

        public void plantar()
        {
            farm.selectPlant(this);
        }
    }
}
