using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    public GameObject Panel;
    public Dropdown DResolution;
    public AudioSource audioSource;
    public Slider SliderVolume;
    public Text TextVolume;

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;
            
            case 1:
                Screen.SetResolution(720, 576, true);
                break;
            
            case 2:
                Screen.SetResolution(1280, 720, true);
                break;
            
            case 3:
                Screen.SetResolution(1920, 1080, true);
                break;
            
            case 4:
                Screen.SetResolution(3840, 2160, true);
                break;
            
            case 5:
                Screen.SetResolution(7680, 4320, true);
                break;
        }
    }

    public void SliderChanger()
    {
        audioSource.volume = SliderVolume.value;
        TextVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
