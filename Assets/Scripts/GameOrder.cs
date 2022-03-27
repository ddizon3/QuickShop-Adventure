using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOrder : MonoBehaviour
{
    public TextMeshProUGUI Apple;
    public TextMeshProUGUI Berry;
    public TextMeshProUGUI Bread;
    public TextMeshProUGUI Cheese;
    public TextMeshProUGUI Fish;
    public TextMeshProUGUI Mushrooms;
    public TextMeshProUGUI Steak;
    public TextMeshProUGUI Turkey;

    public static int apple_count = 0;
    public static int berry_count = 0;
    public static int bread_count = 0;
    public static int cheese_count = 0;
    public static int fish_count = 0;
    public static int mushroom_count = 0;
    public static int steak_count = 0;
    public static int turkey_count = 0;

    void Start()
    {
        DisplayOrder();

    }

     void Update()
    {
        Apple.text = "Apples: " + apple_count;
        Berry.text = "Berries: " + berry_count;
        Bread.text = "Bread: " + bread_count;
        Cheese.text = "Cheese: " + cheese_count;
        Fish.text = "Fish: " + fish_count;
        Mushrooms.text = "Mushrooms: " + mushroom_count;
        Steak.text = "Steak: " + steak_count;
        Turkey.text = "Turkey: " + turkey_count;
    }

    void DisplayOrder()
    {
        int length = OrderController.orderList.Count; //number of items to shop for

        for (int i = 0; i < length; i++) //check each item in grocery list
        {
            string itemName = OrderController.orderList[i].name; //get name of item i
            
            if (itemName.Contains("Apple"))
            {
                apple_count++;
                Apple.text = "Apples: " + apple_count;
            }
            if (itemName.Contains("Berry"))
            {
                berry_count++;
                Berry.text = "Berries: " + berry_count;
            }
            if (itemName.Contains("Bread"))
            {
                bread_count++;
                Bread.text = "Bread: " + bread_count;
            }
            if (itemName.Contains("Cheese"))
            {
                cheese_count++;
                Cheese.text = "Cheese: " + cheese_count;
            }
            if (itemName.Contains("Fish"))
            {
                fish_count++;
                Fish.text = "Fish: " + fish_count;
            }
            if (itemName.Contains("Mushroom"))
            {
                mushroom_count++;
                Mushrooms.text = "Mushrooms: " + mushroom_count;
            }
            if (itemName.Contains("Steak"))
            {
                steak_count++;
                Steak.text = "Steak: " + steak_count;
            }
            if (itemName.Contains("Turkey"))
            {
                turkey_count++;
                Turkey.text = "Turkey: " + turkey_count;
            }

        }

    }
}
