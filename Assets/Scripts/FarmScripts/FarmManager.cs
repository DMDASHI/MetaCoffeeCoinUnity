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
        bool RandomPlant()
        {
            var random = new System.Random();
            return random.Next(2) == 1;
        }

        public int FarmMoneyTest()
        {
            int money = 100;
            Debug.Log("Dinero total " + money);

            money -= 20;
            Debug.Log("- Al Deshierbar = " + money);

            money -= 10;
            Debug.Log("- Al Fertilizar = " + money);
            money -= 10;
            Debug.Log("- Al Plantar = " + money);
            money += 15;
            Debug.Log("+ Al Cosechar = " + money);
            while (true)
            {
                if (!RandomPlant())
                {
                    if (money >= 0 && money - 20 >= 0)
                    {
                        money -= 20;
                        Debug.Log("- Al Deshierbar = " + money);
                    }
                    else
                    {
                        Debug.Log("No es posible deshierbar, por ende no se puede plantar ni fertilizar");
                        break;
                    }

                }
                if (money >= 0 && money - 10 >= 0)
                {
                    money -= 10;
                    Debug.Log("- Al Fertilizar = " + money);
                }
                else
                {
                    Debug.Log("No es posible fertilizar, por ende no es posible plantar");
                    break;
                }
                if (money >= 0 && money - 10 >= 0)
                {
                    money -= 10;
                    Debug.Log("- Al Plantar = " + money);
                    money += 15;
                    Debug.Log("+ Al Cosechar = " + money);
                }
                else
                {
                    Debug.Log("No es posible plantar más");
                    break;
                }
            }
            return money;
        }

    }

}
