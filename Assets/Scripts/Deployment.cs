using UnityEngine;
using UnityEngine.UI;

public class Deployment : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;


    [Header("Turret Cost")]
    public Text standardTurretCost;
    public Text missileLauncherCost;
    public Text laserTurretCost;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

        standardTurretCost.text = standardTurret.cost.ToString();
        missileLauncherCost.text = missileLauncher.cost.ToString();
        laserTurretCost.text = laserTurret.cost.ToString();

    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }

    public void UpgradeStandardTurret()
    {
        standardTurret.isUpgraded = true;
        standardTurretCost.text = standardTurret.upgradedCost.ToString();
        standardTurret.upgradeImage.SetActive(true);
    }

    public void UpgradeMissileLauncher()
    {
        missileLauncher.isUpgraded = true;
        missileLauncherCost.text = missileLauncher.upgradedCost.ToString();
        missileLauncher.upgradeImage.SetActive(true);
    }

    public void UpgradeLaserTurret()
    {
        laserTurret.isUpgraded = true;
        laserTurretCost.text = laserTurret.upgradedCost.ToString();
        laserTurret.upgradeImage.SetActive(true);
    }
}
