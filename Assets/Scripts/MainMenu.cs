using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelSelect;

    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelSelect);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
