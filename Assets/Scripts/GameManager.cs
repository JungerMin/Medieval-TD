using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerStats playerStatsInstance;
    [HideInInspector]
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
        GameIsOver = false;
    }
    private void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (!playerStatsInstance.IsAlive())
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;

        gameOverUI.SetActive(true);
    }
}
