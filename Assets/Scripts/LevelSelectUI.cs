using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    public GameObject levelSelectUI;
    public Text stageName;
    public SceneFader sceneFader;
    public GameObject turretUpgradeMenu;

    private Transform mainCamera;
    private LevelNode level;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (levelSelectUI.activeSelf)
        {
            SetPosition();
            SetLevelName();
        }
    }

    private void SetPosition()
    {
        levelSelectUI.GetComponent<RectTransform>().rotation = mainCamera.rotation;
        return;
    }

    public void SetLocation(LevelNode _level)
    {
        level = _level;

        transform.position = level.GetPosition();
        levelSelectUI.SetActive(true);
    }

    public void Hide()
    {
        levelSelectUI.SetActive(false);
    }

    public void SetLevelName()
    {
        stageName.text = level.levelName;
    }

    public void StartLevel()
    {
        sceneFader.FadeTo(level.GetLevel());
    }

    public void TurretUpgradeMenu()
    {
        turretUpgradeMenu.SetActive(true);
    }
}
