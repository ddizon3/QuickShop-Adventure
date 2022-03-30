using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float currentTime = 0f;
    float startingTime = 60f;

    public TextMeshProUGUI time;

    void Start()
    {
        currentTime = startingTime;
        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        time.text = minutes + ":" + seconds;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        time.text = minutes + ":" + seconds;

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

    }
}
