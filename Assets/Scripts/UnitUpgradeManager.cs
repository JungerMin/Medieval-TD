using UnityEngine;
using UnityEngine.UI;

public class UnitUpgradeManager : MonoBehaviour
{
    private int upgradePoints;

    public Text upgradePointsText;
    public GameObject archerIcon;
    public GameObject mageIcon;
    public GameObject defenderIcon;
    public GameObject menu;

    private void Start()
    {
        upgradePoints = PlayerPrefs.GetInt("UpgradePoints");
        CheckArcher();
        CheckDefender();
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

    public void UpgradeDefender()
    {
        if (upgradePoints > 0)
        {
            defenderIcon.SetActive(true);
            PlayerPrefs.SetInt("Defender", 1);
            PlayerPrefs.SetInt("UpgradePoints", upgradePoints - 1);
            upgradePoints--;
        }
    }

    public void CheckDefender()
    {
        if (PlayerPrefs.GetInt("Defender") == 1)
        {
            defenderIcon.SetActive(true);
        }
    }

    public void ExitMenu()
    {
        menu.SetActive(false);
    }
}
