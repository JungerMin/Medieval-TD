using UnityEngine;

public class Deployment : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void DeployStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
}
