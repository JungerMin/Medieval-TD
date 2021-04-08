using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.DeploymentPoints >= turretToBuild.cost; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.DeploymentPoints < turretToBuild.cost)
        {
            Debug.Log("Not enough Deploymentpoints!");
            return;
        }

        PlayerStats.DeploymentPoints -= turretToBuild.cost;

        GameObject turret = (GameObject) Instantiate(turretToBuild.turretPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Deploymentpoints left: " + PlayerStats.DeploymentPoints);
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
