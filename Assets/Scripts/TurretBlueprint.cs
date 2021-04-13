using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject turretPrefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradedCost;
    public bool isUpgraded = false;
    public GameObject upgradeImage;

    public GameObject buildEffect;
    public GameObject sellEffect;

    public int GetSellAmount()
    {
        if (isUpgraded)
        {
            return upgradedCost / 2;
        }
        else
        {
            return cost / 2;
        }
    }
}
