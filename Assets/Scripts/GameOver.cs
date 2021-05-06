using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;

    public string mainMenu = "MainMenu";

    public void Restart()
    {
        sceneFader.FadeTo(mainMenu);
    }
}
