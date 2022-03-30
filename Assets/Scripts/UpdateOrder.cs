using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//called when GroceryGame scene is loaded
public class UpdateOrder : MonoBehaviour
{
    public GameObject[] groceryItems; //holds all possible grocery items
    public static bool bombHit = false;

    void Update()
    {
        if (bombHit)
        {
            AddToOrder();
            bombHit = false;
        }
    }

    public void AddToOrder() //when the player is bombed
    {
        //add 5 random items to shopping list
        for (int i = 0; i < 5; i++)
        {
            int j = Random.Range(0, 8);
            OrderController.orderList.Add(groceryItems[j].name);
        }

        OrderGUI.bombHit = true; //display updated order
    }
}
