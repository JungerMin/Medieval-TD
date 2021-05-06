using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    public static LevelSelectManager instance;
    public LevelSelectUI levelSelectUI;

    private LevelNode levelNode;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one LevelSelectManager in scene!");
            return;
        }
        instance = this;
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
}
