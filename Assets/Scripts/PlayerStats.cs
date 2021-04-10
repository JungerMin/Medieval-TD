using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one PlayerStats in scene!");
            return;
        }
        instance = this;
    }

    public static int DeploymentPoints;
    public int startDP = 4;

    public static int Lives;
    public int startHP = 3;

    private void Start()
    {
        DeploymentPoints = startDP;
        Lives = startHP;

        StartCoroutine(DPRegen());
    }

    private void Update()
    {
        DeploymentPoints = (int) Mathf.Clamp(DeploymentPoints, 0f, 99f);
        Lives = (int) Mathf.Clamp(Lives, 0f, Mathf.Infinity);
    }

    private IEnumerator DPRegen()
    {
        while (true)
        {
            DeploymentPoints++;
            yield return new WaitForSeconds(1);
        }
    }

    public void ReduceLives()
    {
        Lives--;
    }

    public void AddDP(int dp)
    {
        DeploymentPoints += dp;
    }

    public int GetDP()
    {
        return DeploymentPoints;
    }

    public void ReduceDP(int cost)
    {
        DeploymentPoints -= cost;
    }

    public bool IsAlive()
    {
        return Lives != 0;
    }
}
