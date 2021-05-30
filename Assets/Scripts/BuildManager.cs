using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public NodeUI nodeUI;
    public Deployment deployment;

    public static string ranged = "Ranged";
    public static string melee = "Melee";
    public static string meleeTile = "MeleeTile";
    public static string rangedTile = "RangedTile";

    private PlayerStats playerStatsInstance;
    private Node selectedNode;

    private string type;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        playerStatsInstance = PlayerStats.instance;
    }

    private TurretBlueprint turretToBuild;

    public bool CanBuild (string _type){
        if (_type == rangedTile && type == ranged)
        {
            return true;
        }
        else if (_type == meleeTile && type == melee)
        {
            return true;
        }
        return false;
    }

    public bool HasMoney 
    { get
        { 
            if (turretToBuild.isUpgraded)
            {
                return playerStatsInstance.GetDP() >= turretToBuild.upgradedCost;
            }
            else
            {
                return playerStatsInstance.GetDP() >= turretToBuild.cost;
            }
        } 
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        else if(selectedNode != null)
        {
            selectedNode.Deselect();
        }

        selectedNode = node;
        DeselectTurretToBuild(); ;

        nodeUI.SetTarget(node);
        selectedNode.Select();
    }

    public void DeselectNode()
    {
        if (selectedNode != null)
        {
            selectedNode.Deselect();
        }
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        type = turretToBuild.turretPrefab.tag;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void DeselectTurretToBuild()
    {
        turretToBuild = null;
        type = null;
        deployment.Deselect();
    }

    public bool HasTurret()
    {
        return turretToBuild != null;
    }
}
