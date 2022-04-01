using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrafficGame : ButtonController
{
    [SerializeField] int nextButton;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject[] myObjects;

    //set nextbutton to 0 on start
    void Start(){
        nextButton = 0;
    }
    //randomize the order/ locations of the traffic signs
    private void OnEnable(){
        nextButton = 0;
        for (int i=0; i < myObjects.Length; i++){
            myObjects[i].transform.SetSiblingIndex(Random.Range(0,5));
        }
    }
    //button order function
    public void ButtonOrder(int button){
        int prevButton = 0;
        //if the order is correct continue
        if(button == nextButton){
            nextButton++;
            prevButton = button-1;
        }
        //if the button was pressed in the wrong order reset and scramble the signs (reduce fuel)
        else{
            nextButton=0;

            OnEnable();
        }
        if(button == 5 && prevButton == 4){
            nextButton = 0;
            FinishDelivery();
        }
    }
    private void FinishDelivery(){
        SceneManager.LoadScene("PlayerMenu");
    }
}
