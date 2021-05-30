using UnityEngine;

public class ControlsExplanationController : MonoBehaviour
{
    public GameObject explanations1;
    public GameObject explanations2;
    public GameObject explanations3;
    public SceneFader sceneFader;
    public string levelSelect= "LevelSelect";

    private void Start()
    {
        explanations3.SetActive(false);
        explanations2.SetActive(false);
        explanations1.SetActive(true);
    }

    public void Explanations2()
    {
        explanations1.SetActive(false);
        explanations2.SetActive(true);
    }

    public void Explanations3()
    {
        explanations2.SetActive(false);
        explanations3.SetActive(true);
    }

    public void LevelSelect()
    {
        sceneFader.FadeTo(levelSelect);
    }
}
