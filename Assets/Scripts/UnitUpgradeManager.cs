using UnityEngine;
using UnityEngine.UI;

public class UnitUpgradeManager : MonoBehaviour
{
    private enum Units { ARCHER, MAGE, DEFENDER };
    private Units units;
    private int upgradePoints;

    public Text upgradePointsText;
    public GameObject archerIcon;
    public GameObject mageIcon;
    public GameObject defenderIcon;
    public GameObject menu;
    public GameObject levelSelectTitle;
    public GameObject archerSelected;
    public GameObject mageSelected;
    public GameObject defenderSelected;
    public GameObject notEnoughPoints;

    private void Start()
    {
        upgradePoints = PlayerPrefs.GetInt("UpgradePoints");
        CheckArcher();
        CheckDefender();
        CheckMage();

        archerSelected.SetActive(false);
        mageSelected.SetActive(false);
        defenderSelected.SetActive(false);
    }

    private void Update()
    {
        upgradePointsText.text = "Upgrade Points: " + upgradePoints;
    }

    private void CheckArcher()
    {
        if (PlayerPrefs.GetInt("Archer") == 1)
        {
            archerIcon.SetActive(true);
        }
    }

    private void CheckMage()
    {
        if (PlayerPrefs.GetInt("Mage") == 1)
        {
            mageIcon.SetActive(true);
        }
    }

    private void CheckDefender()
    {
        if (PlayerPrefs.GetInt("Defender") == 1)
        {
            defenderIcon.SetActive(true);
        }
    }

    private void UpgradeArcher()
    {
        if (upgradePoints > 0 && PlayerPrefs.GetInt("Archer") == 0)
        {
            archerIcon.SetActive(true);
            PlayerPrefs.SetInt("Archer", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
            notEnoughPoints.SetActive(false);
        }
        else
        {
            notEnoughPoints.SetActive(true);
        }

        archerSelected.SetActive(false);
        mageSelected.SetActive(false);
        defenderSelected.SetActive(false);
    }

    private void UpgradeMage()
    {
        if (upgradePoints > 0 && PlayerPrefs.GetInt("Mage") == 0)
        {
            mageIcon.SetActive(true);
            PlayerPrefs.SetInt("Mage", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
            notEnoughPoints.SetActive(false);
        }
        else
        {
            notEnoughPoints.SetActive(true);
        }

        archerSelected.SetActive(false);
        mageSelected.SetActive(false);
        defenderSelected.SetActive(false);
    }

    private void UpgradeDefender()
    {
        if (upgradePoints > 0 && PlayerPrefs.GetInt("Defender") == 0)
        {
            defenderIcon.SetActive(true);
            PlayerPrefs.SetInt("Defender", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
            notEnoughPoints.SetActive(false);
        }
        else
        {
            notEnoughPoints.SetActive(true);
        }

        archerSelected.SetActive(false);
        mageSelected.SetActive(false);
        defenderSelected.SetActive(false);
    }

    public void DetailsArcher()
    {
        if (PlayerPrefs.GetInt("Archer") == 0)
        {
            archerSelected.SetActive(true);

            units = Units.ARCHER;
        }
        mageSelected.SetActive(false);
        defenderSelected.SetActive(false);

        notEnoughPoints.SetActive(false);
    }

    public void DetailsMage()
    {

        if (PlayerPrefs.GetInt("Mage") == 0)
        {
            mageSelected.SetActive(true);

            units = Units.MAGE;
        }
        archerSelected.SetActive(false);
        defenderSelected.SetActive(false);
        
        notEnoughPoints.SetActive(false);
    }

    public void DetailsDefender()
    {
        if (PlayerPrefs.GetInt("Defender") == 0)
        {
            defenderSelected.SetActive(true);

            units = Units.DEFENDER;
        }
        archerSelected.SetActive(false);
        mageSelected.SetActive(false);
                
        notEnoughPoints.SetActive(false);
    }

    public void ConfirmUpgrade()
    {
        if (units == Units.ARCHER)
        {
            UpgradeArcher();
        }
        else if (units == Units.MAGE)
        {
            UpgradeMage();
        }
        else if (units == Units.DEFENDER)
        {
            UpgradeDefender();
        }
        else
        {
            return;
        }
    }

    public void ExitMenu()
    {
        menu.SetActive(false);
        levelSelectTitle.SetActive(true);
    }
}
