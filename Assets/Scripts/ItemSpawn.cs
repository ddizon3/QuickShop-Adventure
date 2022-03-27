using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] specialItems;
    public GameObject[] groceryItems;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        float delay_g = Random.Range(0.5f, 1f);
        InvokeRepeating("SpawnGrocery", delay_g, delay_g);

        float delay_s = Random.Range(1.5f, 2.5f);
        InvokeRepeating("SpawnPowerUps", delay_s, delay_s);
    }

    void SpawnGrocery()
    {
        int i = Random.Range(0, 7); //choose random grocery item
        var thisGroceryItem = Instantiate(groceryItems[i], new Vector3(Random.Range(-523, 523), 400, 0), Quaternion.identity);
        thisGroceryItem.transform.SetParent(canvas.transform, false); //sets canvas as the parent for instantiated object
        
        // Kills the game object in 5 seconds after loading the object
        Destroy(thisGroceryItem, 5);
    }

    void SpawnPowerUps()
    {
        int j = Random.Range(0, 3);
        var thisSpecialItem = Instantiate(specialItems[j], new Vector3(Random.Range(-466, 466), 290, 0), Quaternion.identity);
        thisSpecialItem.transform.SetParent(canvas.transform, false);

        // Kills the game object in 5 seconds after loading the object
        Destroy(thisSpecialItem, 5);
    }

}
