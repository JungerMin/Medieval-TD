using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerStats playerStatsInstance;
    private bool gameEnd = false;

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
    }
    private void Update()
    {
        if (gameEnd)
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
        gameEnd = true;
        Debug.Log("Game Over!");
    }
}
