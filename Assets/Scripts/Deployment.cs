using UnityEngine;
using UnityEngine.UI;

public class Deployment : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;


    [Header("Turret Cost")]
    public Text standardTurretCost;
    public Text missileLauncherCost;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

        standardTurretCost.text = standardTurret.cost.ToString();
        missileLauncherCost.text = missileLauncher.cost.ToString();

    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }


}
