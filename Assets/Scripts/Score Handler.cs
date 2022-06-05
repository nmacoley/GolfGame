using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{

    public TextMeshProUGUI ChangingScore;

    private void ProcessOnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) | Input.GetKeyUp("joystick button 1"))
        {
            Debug.Log("Pressed left click.");
            ChangingScore.text = "test";
        }

    }
    /*private void IncreaseScore()
    {

        if (Input.GetMouseButtonUp(0) | Input.GetKeyUp("joystick button 1"))
        {
            ChangingScore.text = "test";
        }
    }*/
}
