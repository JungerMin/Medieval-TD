using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int DeploymentPoints;
    public int startDP = 4;

    private void Start()
    {
        DeploymentPoints = startDP;
        StartCoroutine(DPRegen());
    }

    IEnumerator DPRegen()
    {
        while (true)
        {
            DeploymentPoints++;
            yield return new WaitForSeconds(1);
        }
    }
}
