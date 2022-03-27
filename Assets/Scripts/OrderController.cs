using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderController : MonoBehaviour
{
    public TextMeshProUGUI Items;
    public TextMeshProUGUI Distance;
    public TextMeshProUGUI Gas;
    public TextMeshProUGUI Pay;

    public GameObject[] groceryItems;
    public static List<GameObject> orderList = new List<GameObject>();
    public static int numOfItems;
    private float distance;
    private float gas;
    private float pay;

    private int fuelConsumption = 15; //x km/L (will get from car specs later)

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
        //generate random number of items
        numOfItems = Random.Range(10, 15);
        Items.text = "Items: " + numOfItems; //display
        
        //fill order with random items from grocery array
        for (int i = 0; i < numOfItems; i++)
        {
            int j = Random.Range(0, 7);
            orderList.Add(groceryItems[j]);
            print(i+1 + " of " + numOfItems + " list item: " + orderList[i]);

        }

        //generate a random distance
        distance = NextFloat(1, 6);
        Distance.text = "Distance: " + distance.ToString("0.0") + "KM"; //display

        //calculate gas usage
        gas = distance / fuelConsumption;
        Gas.text = "Gas: " + gas.ToString("0.00") + "L"; //display

        //calculate pay
        pay = (float)(5 + (distance * 0.33) + (numOfItems * 0.45));
        Pay.text = pay.ToString("c2"); //display
    }
}
