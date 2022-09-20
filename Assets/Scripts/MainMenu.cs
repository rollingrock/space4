using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas OptionsCanvas;
    public SoundManagerUI SoundManagerUI;

    private void Start()
    {
        OptionsCanvas.enabled = false;

        // Music manager
        SoundManagerUI.SetStopSoundsOnLevelLoad(true);
        SoundManagerUI.PlayMusic("MainMenuTheme");
    }

    // OnClick Start button
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // OnClick options button
    public void OptionsScreen()
    {
        OptionsCanvas.enabled = !OptionsCanvas.enabled;
    }

    // OnClickQuit
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
