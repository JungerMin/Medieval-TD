using UnityEngine;
using UnityEngine.UI;

public class Deployment : MonoBehaviour
{
    public TurretBlueprint archer;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint mage;

    private int archerUpgrade;
    private int missileLauncherUpgrade;
    private int mageUpgrade;


    [Header("Turret Cost")]
    public Text archerCost;
    public Text missileLauncherCost;
    public Text mageCost;

    BuildManager buildManager;

    private void Start()
    {
        archerUpgrade = PlayerPrefs.GetInt("Archer");
        missileLauncherUpgrade = PlayerPrefs.GetInt("MissileLauncher");
        mageUpgrade = PlayerPrefs.GetInt("Mage");

        buildManager = BuildManager.instance;

        archerCost.text = archer.cost.ToString();
        missileLauncherCost.text = missileLauncher.cost.ToString();
        mageCost.text = mage.cost.ToString();

        CheckArcher();
        CheckMissileLauncher();
        CheckMage();
    }

    public void SelectArcher()
    {
        buildManager.SelectTurretToBuild(archer);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectMage()
    {
        buildManager.SelectTurretToBuild(mage);
    }

    private void CheckArcher()
    {
        if (archerUpgrade == 1)
        {
            archer.isUpgraded = true;
            archerCost.text = archer.upgradedCost.ToString();
            archer.upgradeImage.SetActive(true);
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

    private void CheckMage()
    {
        if (mageUpgrade == 1)
        {
            mage.isUpgraded = true;
            mageCost.text = mage.upgradedCost.ToString();
            mage.upgradeImage.SetActive(true);
        }
    }
}
