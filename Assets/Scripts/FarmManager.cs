using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectedPlant;
    public bool isPlanting = false;
    public Color plantColor = Color.green;
    public Color cancelColor = Color.red;
    public bool isSelected = false;
    public int selectedTool = 0;

    public Image[] buttonsImg;
    public Sprite normalBtn;
    public Sprite selectedButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
        if(toolNumber == selectedTool)
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
}
