using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DeploymentPointsUI : MonoBehaviour
{
    public Text dpText;

    private void Update()
    {
        dpText.text = "DP: " + PlayerStats.DeploymentPoints.ToString();
    }
}
