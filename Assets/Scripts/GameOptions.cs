using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptions : MonoBehaviour
{
    public GameObject Panel;
    public AudioSource audioSource;
    public Slider SliderVolume;
    public Text TextVolume;
    private bool visible = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            // Panel.SetActive(visible);
            if (visible)
            {
                Time.timeScale = 0;
                Panel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                Panel.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void SliderChanger()
    {
        audioSource.volume = SliderVolume.value;
        TextVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
    }
    
    public void ReturnToGame()
    {
        visible = !visible;
        Panel.SetActive(visible);
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
