using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public GameObject mainPanel;
    public AudioSource audioSource;
    public Slider sliderVolume;
    public Text textVolume;
    private bool _visible = false;
    private bool _muted = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)| Input.GetKeyDown("joystick button 7"))
        {
            ShowOptions();
        }
    }

    public void ShowOptions()
    {
        _visible = !_visible;
        mainPanel.SetActive(_visible);
        if (_visible)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void MuteSound()
    {
        if (_muted)
        {
            audioSource.volume = sliderVolume.value;
        }
        else
        {
            audioSource.volume = 0;
        }
        _muted = !_muted;
    }

    public void SliderChanger()
    {
        audioSource.volume = sliderVolume.value;
        textVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
    }
    
    public void ReturnToGame()
    {
        _visible = !_visible;
        mainPanel.SetActive(_visible);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
