using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject confirm;
    public GameObject exitLevel;

    public SceneFader sceneFader;
    public string mainMenu = "MainMenu";

    private float timeScale = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            timeScale = Time.timeScale;

            confirm.SetActive(false);
            exitLevel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = timeScale;
        }
    }

    public void ExitLevel()
    {
        confirm.SetActive(true);
        exitLevel.SetActive(false);
    }

    public void No()
    {
        confirm.SetActive(false);
        exitLevel.SetActive(true);
    }

    public void Yes()
    {
        Toggle();
        Time.timeScale = 1f;
        sceneFader.FadeTo(mainMenu);
    }
}
