using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelSelect;

    public int upgradePoints = 0;

    public SceneFader sceneFader;

    private void Start()
    {
        PlayerPrefs.SetInt("StandardTurret", 0);
        PlayerPrefs.SetInt("MissileLauncher", 0);
        PlayerPrefs.SetInt("LaserTurret", 0);
        PlayerPrefs.SetInt("UpgradePoints", upgradePoints);
    }

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
