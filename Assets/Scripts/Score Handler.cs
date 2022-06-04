using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler1 : MonoBehaviour
{

    public TextMeshProUGUI ChangingScore = 0;

    private void IncreaseScore()
    {
        if (Input.GetMouseButtonDown(0) | Input.GetKeyDown("joystick button 1"))
        {
            ChangingScore.Text = ChangingScore.Text + 1;
        }
    }
}
