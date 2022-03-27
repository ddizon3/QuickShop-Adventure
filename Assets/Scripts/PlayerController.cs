using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 500f;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food" || collision.gameObject.tag == "Special Item")
        {
            Destroy(collision.gameObject);
  
            if(collision.gameObject.name.Contains("Apple") && GameOrder.apple_count > 0)
            {
                GameOrder.apple_count--;
            }
            if (collision.gameObject.name.Contains("Berry") && GameOrder.berry_count > 0)
            {
                GameOrder.berry_count--;
            }
            if (collision.gameObject.name.Contains("Bread") && GameOrder.bread_count > 0)
            {
                GameOrder.bread_count--;
            }
            if (collision.gameObject.name.Contains("Cheese") && GameOrder.cheese_count > 0)
            {
                GameOrder.cheese_count--;
            }
            if (collision.gameObject.name.Contains("Fish") && GameOrder.fish_count > 0)
            {
                GameOrder.fish_count--;
            }
            if (collision.gameObject.name.Contains("Mushroom") && GameOrder.mushroom_count > 0)
            {
                GameOrder.mushroom_count--;
            }
            if (collision.gameObject.name.Contains("Steak") && GameOrder.steak_count > 0)
            {
                GameOrder.steak_count--;
            }
            if (collision.gameObject.name.Contains("Turkey") && GameOrder.turkey_count > 0)
            {
                GameOrder.turkey_count--;
            }
        }
    }
}
