using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeploymentPointsUI : MonoBehaviour
{
    public Text moneyText;

    private void Update()
    {
        moneyText.text = "DP: " + PlayerStats.DeploymentPoints.ToString();
    }
}
