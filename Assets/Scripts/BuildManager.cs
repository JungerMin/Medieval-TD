using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject buildEffect;

    PlayerStats playerStatsInstance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return playerStatsInstance.GetDP() >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (playerStatsInstance.GetDP() < turretToBuild.cost)
        {
            Debug.Log("Not enough Deploymentpoints!");
            return;
        }

        playerStatsInstance.ReduceDP(turretToBuild.cost);

        GameObject turret = (GameObject) Instantiate(turretToBuild.turretPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Deploymentpoints left: " + playerStatsInstance.GetDP());
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
