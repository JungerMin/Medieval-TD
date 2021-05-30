using UnityEngine;
using UnityEngine.UI;

public class Deployment : MonoBehaviour
{
    public TurretBlueprint archer;
    public TurretBlueprint mage;
    public TurretBlueprint defender;

    private int archerUpgrade;
    private int mageUpgrade;
    private int defenderUpgrade;

    [Header("SelectedIcon")]
    public GameObject archerSelected;
    public GameObject mageSelected;
    public GameObject defenderSelected;

    [Header("Turret Cost")]
    public Text archerCost;
    public Text mageCost;
    public Text defenderCost;

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
        Deselect();
        archerSelected.SetActive(true);
    }

    public void SelectMage()
    {
        buildManager.SelectTurretToBuild(mage);
        Deselect();
        mageSelected.SetActive(true);
    }

    public void SelectDefender()
    {
        buildManager.SelectTurretToBuild(defender);
        Deselect();
        defenderSelected.SetActive(true);
    }

    public void Deselect()
    {
        archerSelected.SetActive(false);
        mageSelected.SetActive(false);
        defenderSelected.SetActive(false);
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

    private void CheckMage()
    {
        if (mageUpgrade == 1)
        {
            mage.isUpgraded = true;
            mageCost.text = mage.upgradedCost.ToString();
            mage.upgradeImage.SetActive(true);
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
}
