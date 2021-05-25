using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerStats playerStatsInstance;
    [HideInInspector]
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject completeStageUI;

    private bool toggle = false;

    public float gameTime = 0f;
    public Text gameOverTime;
    public Text stageCompleteTime;
    public Text UITime;
    public Text stageName;

    [Header("SceneFader")]
    public string levelSelect = "LevelSelect";
    public SceneFader sceneFader;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
        GameIsOver = false;
    }
    private void Update()
    {
        if (!playerStatsInstance.IsAlive())
        {
            EndGame();
        }

        if (!GameIsOver)
        {
            gameTime += Time.deltaTime;

            UITime.text = string.Format("{0:00.00}", gameTime);
        }

        if (GameIsOver && playerStatsInstance.IsAlive())
        {
            CompleteStage();
        }
    }

    private void CompleteStage()
    {
        completeStageUI.SetActive(true);

        Time.timeScale = 1f;

        stageCompleteTime.text = string.Format("Duration: {0:00.00}", gameTime);
    }

    private void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);

        Time.timeScale = 1f;

        gameOverTime.text = string.Format("Duration: {0:00.00}", gameTime);
        stageName.text = SceneManager.GetActiveScene().name;
    }

    public void ToggleSpeed()
    {
        if (!toggle)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        toggle = !toggle;
    }

    public void NextStage()
    {
        int upgrade = PlayerPrefs.GetInt("UpgradePoints");
        PlayerPrefs.SetInt("UpgradePoints", ++upgrade);
        PlayerPrefs.SetString("ClearedStage", SceneManager.GetActiveScene().name);

        sceneFader.FadeTo(levelSelect);
    }
}
