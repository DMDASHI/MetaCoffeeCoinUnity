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

        private int money = 100;
        public Text moneyTxt;

        public void Start()
        {
            moneyTxt.text = money + " BTF";
        }

        public void SelectPlant(PlantItem newPlant)
        {
            if (selectedPlant == newPlant)
            {
                CheckSelection();
            }
            else
            {
                CheckSelection();
                selectedPlant = newPlant;
                selectedPlant.btnImage.color = cancelColor;
                selectedPlant.btnTxt.text = "Cancel";
                isPlanting = true;
            }
        }

        public void SelectTool(int toolNumber)
        {
            if (toolNumber == selectedTool)
            {
                CheckSelection();
            }
            else
            {
                CheckSelection();
                isSelected = true;
                selectedTool = toolNumber;
                buttonsImg[toolNumber - 1].sprite = selectedButton;
            }
        }

        void CheckSelection()
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

        public void Transaction(int value)
        {
            money += value;
            moneyTxt.text = money + " BTF";
        }

        public bool GetPlanting()
        {
            return isPlanting;
        }

        public bool GetSelectedT()
        {
            return isSelected;
        }

        public int GetMoney()
        {
            return money;
        }

    }

}
