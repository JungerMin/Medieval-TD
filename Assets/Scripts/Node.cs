using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    public Color notEnoughMoneyColour;
    public Color selectedColour;
    public Color canSelectColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public bool isSelected = false;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;

    private Renderer rend;
    private Color startColour;

    private BuildManager buildManager;
    private PlayerStats playerStatsInstance;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.instance;
        playerStatsInstance = PlayerStats.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }



        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            if (!buildManager.HasTurret())
            {
                buildManager.DeselectNode();
            }
            return;
        }
        else if (buildManager.CanBuild)
        {
            BuildTurret(buildManager.GetTurretToBuild());
            rend.material.color = startColour;
        }       
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null && !isSelected)
        {
            rend.material.color = canSelectColor;
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColour;
        } else
        {
            rend.material.color = notEnoughMoneyColour;
        }
    }

    private void OnMouseExit()
    {
        if (!isSelected)
        {
            rend.material.color = startColour;
        }
    }

    private void BuildTurret (TurretBlueprint blueprint)
    {
        if (playerStatsInstance.GetDP() < blueprint.cost)
        {
            Debug.Log("Not enough Deploymentpoints!");
            return;
        }

        if (blueprint.isUpgraded)
        {
            GameObject _turret = (GameObject)Instantiate(blueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            playerStatsInstance.ReduceDP(blueprint.upgradedCost);
        }
        else
        {
            GameObject _turret = (GameObject)Instantiate(blueprint.turretPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            playerStatsInstance.ReduceDP(blueprint.cost);
        }

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(blueprint.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build!");

        buildManager.DeselectTurretToBuild();
    }

    public void SellTurret()
    {
        PlayerStats.DeploymentPoints += turretBlueprint.GetSellAmount();
        GameObject effect = (GameObject)Instantiate(turretBlueprint.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    public void Select()
    {
        isSelected = true;
        rend.material.color = selectedColour;
    }

    public void Deselect()
    {
        isSelected = false;
        rend.material.color = startColour;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
