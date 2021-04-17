using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject confirm;
    public GameObject exitLevel;

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
            confirm.SetActive(false);
            exitLevel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
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
        // Temporary Restart level
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
