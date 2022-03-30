using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//called when PlayerMenu scene is loaded
public class GameController : MonoBehaviour
{
    public TextMeshProUGUI Rating; 
    public TextMeshProUGUI Balance;
    public TextMeshProUGUI Gas;
    public Image gasLevel;

    public static float rating = 5.0f;
    public static float balance = 0f;
    public static float gas = 20f; //current gas level (start with 20)
    public float maxGas = 20f; //20L tank
    public static float maintenanceLevel;
    public static float gasUsed; //gas usage from the grocery order

    public static List<float> ratings = new List<float>();

    // Update is called once per frame
    void Start()
    {
        float calculatedRating = CalculateRating();
        Rating.text = calculatedRating.ToString("0.0");
        Balance.text = balance.ToString("c2");

        UpdateGas(gasUsed);
        gasUsed = 0;
    }

    public float CalculateRating() //mean of ratings in List
    {
        float sumOfRatings = 0f;
        float newRating = rating;

        if (ratings.Count > 0)
        {
            for (int i = 0; i < ratings.Count; i++)
            {
                sumOfRatings += ratings[i];
            }

            newRating = sumOfRatings / (ratings.Count); 
        }

        return newRating;
    }

    public void UpdateGas(float gasUsed)
    {
        gas = gas - gasUsed; //update tank levels
        Gas.text = gas.ToString("0.00") + " L";
        gasLevel.fillAmount = gas / maxGas; //display on screen (x10 to show on PlayerMenu)

        if (gasLevel.fillAmount <= .50)
        {
            gasLevel.color = Color.yellow;
        }

        if (gasLevel.fillAmount < .25)
        {
            gasLevel.color = Color.red;
        }

    }
}