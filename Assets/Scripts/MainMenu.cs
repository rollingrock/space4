using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas OptionsCanvas;

    private void Start()
    {
        OptionsCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OptionsScreen()
    {
        OptionsCanvas.enabled = !OptionsCanvas.enabled;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
