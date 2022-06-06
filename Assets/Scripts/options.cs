using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public Dropdown dResolution;
    public AudioSource audioSource;
    public Slider sliderVolume;
    public Text textVolume;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void SetResolution()
    {
        switch (dResolution.value)
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
        audioSource.volume = sliderVolume.value;
        textVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
