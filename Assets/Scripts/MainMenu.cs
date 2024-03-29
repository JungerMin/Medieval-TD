using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string explanations = "Explanations";

    public int upgradePoints = 0;

    public SceneFader sceneFader;

    private void Start()
    {
        PlayerPrefs.SetInt("Archer", 0);
        PlayerPrefs.SetInt("Mage", 0);
        PlayerPrefs.SetInt("Defender", 0);
        PlayerPrefs.SetInt("UpgradePoints", upgradePoints);
        PlayerPrefs.SetString("ClearedStage", "Stage 0");
    }

    public void Play()
    {
        sceneFader.FadeTo(explanations);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
