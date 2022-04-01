using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//called when PlayerMenu scene is loaded
public class OrderController : MonoBehaviour
{
    public TextMeshProUGUI Items;
    public TextMeshProUGUI Distance;
    public TextMeshProUGUI Gas;
    public TextMeshProUGUI Pay;

    public Image star1;
    public Image star2;
    public Image star3;

    public Sprite yellowStar;
    public Sprite blankStar;

    public GameObject[] groceryItems; //holds all possible grocery items
    public static List<string> orderList = new List<string>(); //holds items to shop for

    public static int numOfItems;
    private float distance;
    public static float gasUsage;
    public static float pay;

    public static int totalItemsCollected;
    public static int totalCorrectItemsCollected;

    private int fuelConsumption = 10; // km/L
    public static bool timeUp = false;

    void Start()
    {
        CreateOrder();
    }

    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    public void CreateOrder()
    {
        //reset the order before generating a new one
        orderList.Clear();

        //generate random number of items (10 - 15)
        numOfItems = Random.Range(10, 16);
        Items.text = "Items: " + numOfItems; //display     
        
        if (numOfItems >= 10 && numOfItems <= 11)
        {
            // 1 star
            star1.sprite = blankStar;
            star2.sprite = blankStar;
            star3.sprite = yellowStar;

        } else if (numOfItems >= 12 && numOfItems <= 13)
        {
            // 2 stars
            star1.sprite = blankStar;
            star2.sprite = yellowStar;
            star3.sprite = yellowStar;
             
        } else if (numOfItems >= 14 && numOfItems <= 15)
        {
            // 3 stars
            star1.sprite = yellowStar;
            star2.sprite = yellowStar;
            star3.sprite = yellowStar;
        }
        
        //fill order with random items from grocery array
        for (int i = 0; i < numOfItems; i++)
        {
            int j = Random.Range(0, 8);
            orderList.Add(groceryItems[j].name);
        }

        //generate a random distance
        distance = NextFloat(1, 11);
        Distance.text = "Distance: " + distance.ToString("0.0") + "KM"; //display

        //calculate gas usage
        gasUsage = distance / (float)fuelConsumption;
        Gas.text = "Gas: " + gasUsage.ToString("0.00") + "L"; //display

        //calculate pay
        pay = (float)(5 + (distance * 0.33) + (numOfItems * 0.45));
        Pay.text = pay.ToString("c2"); //display
    }

    public static void EndOrder()
    {
        Time.timeScale = 0; //pause game

        if (timeUp)
        {
            //TIME IS UP

            //add base pay ONLY
            GameController.balance += 5;

            //calculate rating from this order
            float failedRating = 3.0f;
            //add to List of ratings
            GameController.ratings.Add(failedRating);

            timeUp = false;
        }
        
        if (orderList.Count == 0)
        {
            //add money to balance
            GameController.balance = GameController.balance + pay;

            //calculate rating from this order
            float newRating = ((float)totalCorrectItemsCollected / (float)totalItemsCollected) * 5.0f;
            //add to List of ratings
            GameController.ratings.Add(newRating);
        }

        //update gas
        GameController.gasUsed = gasUsage;

        print("GAME OVER! transitioning to delivery game...");
        SceneManager.LoadScene("CarGame");
    }
}