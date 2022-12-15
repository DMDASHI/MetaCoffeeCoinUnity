using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Farm
{
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

        Color availableColor = Color.green;
        Color unavailableColor = Color.red;

        bool isDry = true;
        bool isFertilized = false;
        bool hasHerb = true;

        public Sprite drySprite;
        public Sprite normalSprite;
        public Sprite herbSprite;


        private readonly int fertilyzingPrice = 10;
        private readonly int herbPrice = 20;

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
                    timer = selectedPlant.GenerateRandom();
                    plantStage++;

                    updatePlant();
                }
            }
            else if (isDry && !hasHerb)
            {
                plot.sprite = drySprite;
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
                if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.GetPlanting())
                {
                    Harvest();
                }

            }
            else if (fm.GetPlanting() && isFertilized && !isDry && fm.selectedPlant.plant.GetBuyPrice() <= fm.GetMoney())
            {
                Plant(fm.selectedPlant.plant);
            }
            if (fm.GetSelectedT())
            {
                switch (fm.selectedTool)
                {
                    case 1:
                        if (!hasHerb)
                        {
                            Debug.Log("Plot Regada");
                            isDry = false;
                            plot.sprite = normalSprite;
                            if (isPlanted)
                            {
                                updatePlant();
                            }
                        }
                        break;
                    case 2:
                        if (fm.GetMoney() > herbPrice)
                        {
                            Debug.Log("Plot deshierbada");
                            hasHerb = false;
                            plot.sprite = drySprite;
                            fm.Transaction(-herbPrice); 
                        }
                        break;
                    case 3:
                        if (!hasHerb && fm.GetMoney() > fertilyzingPrice)
                        {
                            Debug.Log("Plot fertilizada");
                            isFertilized = true;
                            fm.Transaction(-fertilyzingPrice);
                        }
                        break; 
                    default:
                        break;
                }

            }
        }

        private void OnMouseOver()
        {
            if (fm.GetPlanting())
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
            if (fm.GetSelectedT())
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
                        if (hasHerb && fm.GetMoney() > herbPrice + 20)
                        {
                            plot.color = availableColor;
                        }
                        else
                        {
                            plot.color = unavailableColor;
                        }
                        break;
                    case 3:
                        if (!isFertilized && !hasHerb && fm.GetMoney() > fertilyzingPrice + 10)
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
            fm.Transaction(selectedPlant.GetSellPrice());
            isDry = true;
            isFertilized = false;
            Debug.Log("Planta recolectada");
            if (RandomPlant())
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
            Debug.Log("Se plantó");
            selectedPlant = newPlant;
            fm.Transaction(-selectedPlant.GetBuyPrice());
            isPlanted = true;
            plantStage = 0;
            updatePlant();
            timer = selectedPlant.GenerateRandom();
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
            isDry = RandomPlant();
        }

        bool RandomPlant()
        {
            var random = new System.Random();
            return random.Next(2) == 1;
        }
    }

}
