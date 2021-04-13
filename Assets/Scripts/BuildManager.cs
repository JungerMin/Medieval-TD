using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public NodeUI nodeUI;

    private PlayerStats playerStatsInstance;
    private Node selectedNode;

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

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return playerStatsInstance.GetDP() >= turretToBuild.cost; } }

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
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void DeselectTurretToBuild()
    {
        turretToBuild = null;
    }

    public bool HasTurret()
    {
        return turretToBuild != null;
    }
}
