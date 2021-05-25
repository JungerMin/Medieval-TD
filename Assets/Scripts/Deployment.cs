using UnityEngine;
using UnityEngine.UI;

public class Deployment : MonoBehaviour
{
    public TurretBlueprint archer;
    public TurretBlueprint defender;
    public TurretBlueprint mage;

    private int archerUpgrade;
    private int defenderUpgrade;
    private int mageUpgrade;


    [Header("Turret Cost")]
    public Text archerCost;
    public Text defenderCost;
    public Text mageCost;

    BuildManager buildManager;

    private void Start()
    {
        archerUpgrade = PlayerPrefs.GetInt("Archer");
        defenderUpgrade = PlayerPrefs.GetInt("Defender");
        mageUpgrade = PlayerPrefs.GetInt("Mage");

        buildManager = BuildManager.instance;

        archerCost.text = archer.cost.ToString();
        defenderCost.text = defender.cost.ToString();
        mageCost.text = mage.cost.ToString();

        CheckArcher();
        CheckDefender();
        CheckMage();
    }

    public void SelectArcher()
    {
        buildManager.SelectTurretToBuild(archer);
    }

    public void SelectDefender()
    {
        buildManager.SelectTurretToBuild(defender);
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

    private void CheckDefender()
    {
        if (defenderUpgrade == 1)
        {
            defender.isUpgraded = true;
            defenderCost.text = defender.upgradedCost.ToString();
            defender.upgradeImage.SetActive(true);
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
