using UnityEngine;

public class ControlsExplanationController : MonoBehaviour
{
    public GameObject controls;
    public GameObject unitsExplanation;
    public SceneFader sceneFader;
    public string levelSelect= "LevelSelect";

    private void Start()
    {
        unitsExplanation.SetActive(false);
        controls.SetActive(true);
    }

    public void ContinueToUnitsExplanation()
    {
        unitsExplanation.SetActive(true);
    }

    public void LevelSelect()
    {
        sceneFader.FadeTo(levelSelect);
    }
}
