using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class FarmManager : MonoBehaviour
    {
        public PlantItem selectedPlant;
        private bool isPlanting = false;
        Color plantColor = Color.green;
        Color cancelColor = Color.red;
        private bool isSelected = false;
        public int selectedTool = 0;

        public Image[] buttonsImg;
        public Sprite normalBtn;
        public Sprite selectedButton;


        public void selectPlant(PlantItem newPlant)
        {
            if (selectedPlant == newPlant)
            {
                checkSelection();
            }
            else
            {
                checkSelection();
                selectedPlant = newPlant;
                selectedPlant.btnImage.color = cancelColor;
                selectedPlant.btnTxt.text = "Cancel";
                isPlanting = true;
            }
        }

        public void selectTool(int toolNumber)
        {
            if (toolNumber == selectedTool)
            {
                checkSelection();
            }
            else
            {
                checkSelection();
                isSelected = true;
                selectedTool = toolNumber;
                buttonsImg[toolNumber - 1].sprite = selectedButton;
            }
        }

        void checkSelection()
        {
            if (isPlanting)
            {
                isPlanting = false;
                if (selectedPlant != null)
                {
                    selectedPlant.btnImage.color = plantColor;
                    selectedPlant.btnTxt.text = "Plant";
                    selectedPlant = null;
                }
            }
            if (isSelected)
            {
                if (selectedTool > 0)
                {
                    buttonsImg[selectedTool - 1].sprite = normalBtn;
                }
                isSelected = false;
                selectedTool = 0;
            }
        }

        public void transaction(string message)
        {
            Debug.Log(message);
        }

        public bool getPlanting()
        {
            return isPlanting;
        }

        public bool getSelectedT()
        {
            return isSelected;
        }
    }

}
