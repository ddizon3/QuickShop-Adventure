using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public void ChangeToGameMenu()
    {
        SceneManager.LoadScene("PlayerMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeToCarShop()
    {
        SceneManager.LoadScene("CarShop");
    }

    public void ChangeToGroceryGame()
    {
        SceneManager.LoadScene("GroceryGame");
    }
}
