using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager instance;
    public LevelSelectUI levelSelectUI;
    public GameObject winScreen;
    public SceneFader sceneFader;

    public string mainMenu = "MainMenu";

    private LevelNode levelNode;
    private string clearedStage;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one LevelSelectManager in scene!");
            return;
        }
        instance = this;

        winScreen.SetActive(false);

        clearedStage = PlayerPrefs.GetString("ClearedStage");
    }

    private void Update()
    {
        if (clearedStage == "Stage 3-2" || clearedStage =="Stage 3-1")
        {
            winScreen.SetActive(true);
        }
    }

    public void SelectLevel(LevelNode _levelNode)
    {
        if (levelNode == _levelNode)
        {
            DeselectLevel();
            return;
        }
        else if (levelNode != null)
        {
            levelNode.Deselect();
        }

        levelNode = _levelNode;
        levelSelectUI.SetLocation(_levelNode);
        levelNode.Select();
    }

    public void DeselectLevel()
    {
        if (levelNode != null)
        {
            levelNode.Deselect();
        }
        levelNode = null;
        levelSelectUI.Hide();
    }

    public void BackToTitle()
    {
        sceneFader.FadeTo(mainMenu);
    }
}
