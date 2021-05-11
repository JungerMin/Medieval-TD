using UnityEngine;
using UnityEngine.UI;

public class Deployment : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;

    private int standardTurretUpgrade;
    private int missileLauncherUpgrade;
    private int laserTurretUpgrade;


    [Header("Turret Cost")]
    public Text standardTurretCost;
    public Text missileLauncherCost;
    public Text laserTurretCost;

    BuildManager buildManager;

    private void Start()
    {
        standardTurretUpgrade = PlayerPrefs.GetInt("StandardTurret");
        missileLauncherUpgrade = PlayerPrefs.GetInt("MissileLauncher");
        laserTurretUpgrade = PlayerPrefs.GetInt("laserTurret");

        buildManager = BuildManager.instance;

        standardTurretCost.text = standardTurret.cost.ToString();
        missileLauncherCost.text = missileLauncher.cost.ToString();
        laserTurretCost.text = laserTurret.cost.ToString();

        CheckStandardTurret();
        CheckMissileLauncher();
        CheckLaserTurret();
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

    private void CheckStandardTurret()
    {
        if (standardTurretUpgrade == 1)
        {
            standardTurret.isUpgraded = true;
            standardTurretCost.text = standardTurret.upgradedCost.ToString();
            standardTurret.upgradeImage.SetActive(true);
        }
    }

    private void CheckMissileLauncher()
    {
        if (missileLauncherUpgrade == 1)
        {
            missileLauncher.isUpgraded = true;
            missileLauncherCost.text = missileLauncher.upgradedCost.ToString();
            missileLauncher.upgradeImage.SetActive(true);
        }
    }

    private void CheckLaserTurret()
    {
        if (laserTurretUpgrade == 1)
        {
            laserTurret.isUpgraded = true;
            laserTurretCost.text = laserTurret.upgradedCost.ToString();
            laserTurret.upgradeImage.SetActive(true);
        }
    }
}
