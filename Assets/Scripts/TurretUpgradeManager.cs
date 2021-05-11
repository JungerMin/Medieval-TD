using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurretUpgradeManager : MonoBehaviour
{
    private int upgradePoints;

    public Text upgradePointsText;
    public GameObject standardTurretIcon;
    public GameObject missileLauncherIcon;
    public GameObject laserTurretIcon;
    public GameObject menu;

    private void Start()
    {
        upgradePoints = PlayerPrefs.GetInt("UpgradePoints");
        CheckStandardTurret();
        CheckMissileLauncher();
        CheckLaserTurret();
    }

    private void Update()
    {
        upgradePointsText.text = "Upgrade Points: " + upgradePoints;
    }

    public void UpgradeStandardTurret()
    {
        if (upgradePoints > 0)
        {
            standardTurretIcon.SetActive(true);
            PlayerPrefs.SetInt("StandardTurret", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
        }
    }

    public void CheckStandardTurret()
    {
        if(PlayerPrefs.GetInt("StandardTurret") == 1)
        {
            standardTurretIcon.SetActive(true);
        }
    }

    public void UpgradeMissileLauncher()
    {
        if (upgradePoints > 0)
        {
            missileLauncherIcon.SetActive(true);
            PlayerPrefs.SetInt("MissileLauncher", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
        }
    }

    public void CheckMissileLauncher()
    {
        if (PlayerPrefs.GetInt("MissileLauncher") == 1)
        {
            missileLauncherIcon.SetActive(true);
        }
    }

    public void UpgradeLaserTurret()
    {
        if (upgradePoints > 0)
        {
            laserTurretIcon.SetActive(true);
            PlayerPrefs.SetInt("LaserTurret", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
        }
    }

    public void CheckLaserTurret()
    {
        if (PlayerPrefs.GetInt("LaserTurret") == 1)
        {
            laserTurretIcon.SetActive(true);
        }
    }

    public void ExitMenu()
    {
        menu.SetActive(false);
    }
}
