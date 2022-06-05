using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler1 : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI ChangingScore;

    private void ProcessOnMouseUp()
    {
        if (Input.GetMouseButtonUp(0) | Input.GetKeyUp("joystick button 1"))
        {
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
