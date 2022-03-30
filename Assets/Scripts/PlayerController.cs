using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ran in the GroceryGame Scene
public class PlayerController : MonoBehaviour
{
    public float speed = 500f;

    void Start()
    {
        Time.timeScale = 1; //resume game
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;

        if (Timer.currentTime <= 0)
        {
            OrderController.timeUp = true;
            OrderController.EndOrder();
            Timer.currentTime = 60f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);

            OrderController.totalItemsCollected++;
  
            if(collision.gameObject.name.Contains("Apple") && OrderGUI.apple_count > 0)
            {
                OrderGUI.apple_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Berry") && OrderGUI.berry_count > 0)
            {
                OrderGUI.berry_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Bread") && OrderGUI.bread_count > 0)
            {
                OrderGUI.bread_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Cheese") && OrderGUI.cheese_count > 0)
            {
                OrderGUI.cheese_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Fish") && OrderGUI.fish_count > 0)
            {
                OrderGUI.fish_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Mushroom") && OrderGUI.mushroom_count > 0)
            {
                OrderGUI.mushroom_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Steak") && OrderGUI.steak_count > 0)
            {
                OrderGUI.steak_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }
            if (collision.gameObject.name.Contains("Turkey") && OrderGUI.turkey_count > 0)
            {
                OrderGUI.turkey_count--; //update GUI
                OrderController.orderList.Remove(collision.gameObject.name); //update orderList
                OrderController.totalCorrectItemsCollected++;
            }

            if (OrderController.orderList.Count == 0)
            {
                OrderController.EndOrder();
            }
        }

        if (collision.gameObject.tag == "Special Item")
        {
            Destroy(collision.gameObject);

            //special items
            if (collision.gameObject.name.Contains("Coin"))
            {
                //increase pay +$1
                OrderController.pay++;
            }
            if (collision.gameObject.name.Contains("Gas"))
            {
                //increase gas in tank +1L
                if (GameController.gas <= 20 && GameController.gas >= 19)
                {
                    GameController.gas = 20f;
                } else
                {
                    GameController.gas++;
                }
            }
            if (collision.gameObject.name.Contains("Hourglass"))
            {
                //increase time +15sec
                Timer.currentTime += 15f;
            }
            if (collision.gameObject.name.Contains("Bomb"))
            {
                //add additional items to shopping
                UpdateOrder.bombHit = true; //add items to OrderList
            }
        }
    }
}