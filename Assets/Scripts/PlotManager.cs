using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{

    bool isPlanted = false;

    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    FarmManager fm;
    SpriteRenderer plot;
    PlantObject selectedPlant;

    int plantStage = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    bool isDry = true;
    bool isFertilized = false;
    bool hasHerb = true;
    public Sprite drySprite;
    public Sprite normalSprite;
    public Sprite herbSprite;


    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        plot = transform.GetComponent<SpriteRenderer>();
        plot.sprite = herbSprite;    
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted && !isDry)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.generateRandom();
                plantStage++;
                
                updatePlant();
                
            }
        }
    }
    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }

        }
        else if (fm.isPlanting && isFertilized && !isDry)
        {
            Plant(fm.selectedPlant.plant);
        }
        if (fm.isSelected)
        {
            switch (fm.selectedTool)
            {
                case 1:
                    if (!hasHerb)
                    {
                        isDry = false;
                        plot.sprite = normalSprite;
                        if (isPlanted)
                        {
                            updatePlant();
                        }
                    }
                    break;
                case 2:
                    hasHerb = false;
                    plot.sprite = drySprite;
                    break;
                case 3:
                    isFertilized = true;
                    break;
                default:
                    break;
            }
                
        }
    }

    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if (isPlanted || !isFertilized || isDry)
            {
                plot.color = unavailableColor;
            }
            else
            {
                plot.color = availableColor;
            }
        }
        if (fm.isSelected)
        {

            switch (fm.selectedTool)
            {
                case 1:
                    if (!isDry || hasHerb)
                    {
                        plot.color = unavailableColor;
                    }
                    else
                    {
                        plot.color = availableColor;
                    }
                    break;
                case 2:
                    if (hasHerb)
                    {
                        plot.color = availableColor;
                    }
                    else
                    {
                        plot.color = unavailableColor;
                    }
                    break;
                case 3:
                    if (!isFertilized || hasHerb)
                    {
                        plot.color = availableColor;
                    }
                    else
                    {
                        plot.color = unavailableColor;
                    }
                    break;
                default:
                    plot.color = unavailableColor;
                    break;
            }
        }
    }
    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        fm.transaction("Harvesting");
        isDry = true;
        isFertilized = false;
        if(randomPlant())
        {
            plot.sprite = drySprite;
        }
        else
        {
            plot.sprite = herbSprite;
            hasHerb = true;
        }
        
    }

    void Plant(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        fm.transaction("Planting");
        isPlanted = true;
        plantStage = 0;
        updatePlant();
        timer = selectedPlant.generateRandom();
        plant.gameObject.SetActive(true);
    }

    void updatePlant()
    {
        if (isDry)
        {
            plot.sprite = drySprite; 
        }
        else
        {
            plant.sprite = selectedPlant.plantStages[plantStage];
        }
        plantCollider.size = plant.sprite.bounds.size;
        isDry = randomPlant();
        
    }

    bool randomPlant()
    {
        var random = new System.Random();
        return random.Next(2) == 1;
    }
}
