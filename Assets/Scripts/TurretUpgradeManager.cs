using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurretUpgradeManager : MonoBehaviour
{
    private int upgradePoints;

    public Text upgradePointsText;
    public GameObject archerIcon;
    public GameObject missileLauncherIcon;
    public GameObject mageIcon;
    public GameObject menu;

    private void Start()
    {
        upgradePoints = PlayerPrefs.GetInt("UpgradePoints");
        CheckArcher();
        CheckMissileLauncher();
        CheckMage();
    }

    private void Update()
    {
        upgradePointsText.text = "Upgrade Points: " + upgradePoints;
    }

    public void UpgradeArcher()
    {
        if (upgradePoints > 0)
        {
            archerIcon.SetActive(true);
            PlayerPrefs.SetInt("Archer", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
        }
    }

    public void CheckArcher()
    {
        if(PlayerPrefs.GetInt("Archer") == 1)
        {
            archerIcon.SetActive(true);
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

    public void UpgradeMage()
    {
        if (upgradePoints > 0)
        {
            mageIcon.SetActive(true);
            PlayerPrefs.SetInt("Mage", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
        }
    }

    public void CheckMage()
    {
        if (PlayerPrefs.GetInt("Mage") == 1)
        {
            mageIcon.SetActive(true);
        }
    }

    public void ExitMenu()
    {
        menu.SetActive(false);
    }
}
