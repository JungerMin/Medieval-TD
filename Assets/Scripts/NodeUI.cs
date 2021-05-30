using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private enum UnitType {MELEE, RANGED};
    private UnitType unitType;


    public GameObject nodeUI;


    [Header("UI Position")]
    public GameObject backPoint;
    private Transform mainCamera;

    [Header("Turret Stats")]
    public Text attack;
    public Text secondary;
    public Text price;

    private Node target;
    private Ranged ranged;
    private Melee melee;
    private TurretBlueprint turretBlueprint;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        

        if (nodeUI.activeSelf == true)
        {
            if (target.turret == null)
            {
                Hide();
                return;
            }
            SetPosition();
        }
    }

    private void SetPosition()
    {
        nodeUI.GetComponent<RectTransform>().rotation = mainCamera.rotation;

        Vector3 dir = backPoint.transform.position - transform.position;
        dir = new Vector3(dir.x, 0, dir.z);

        float scaling = 0.04f * mainCamera.position.y + 0.57f;

        transform.position = target.GetBuildPosition() + dir.normalized * scaling;

        if (target.turret != null)
        {
            if (target.turret.tag == "Melee")
            {
                melee = target.turret.GetComponent<Melee>();
            }
            else if (target.turret.tag == "Ranged")
            {
                ranged = target.turret.GetComponent<Ranged>();
            }
        }
        
        turretBlueprint = target.turretBlueprint;

        SetAttack();
        SetSecondary();
        SetSell();

        target.turret.GetComponent<RangeIndicator>().SetActive(true);
    }

    public void SetTarget(Node _target)
    {
        if (target != null)
        {
            target.turret.GetComponent<RangeIndicator>().SetActive(false);
        }

        target = _target;

        transform.position = target.GetBuildPosition();

        nodeUI.SetActive(true);

        if (target.turret.tag == "Melee")
        {
            unitType = UnitType.MELEE;
        }
        else if (target.turret.tag == "Ranged")
        {
            unitType = UnitType.RANGED;
        }
    }

    public void Hide()
    {
        nodeUI.SetActive(false);
        if (target != null)
        {
            target.turret.GetComponent<RangeIndicator>().SetActive(false);
        }
    }

    public void SetAttack()
    {
        if (unitType == UnitType.RANGED)
        {
            attack.text = "Dmg: " + ranged.damage.ToString();
        }

        if (unitType == UnitType.MELEE)
        {
            attack.text = "Dmg: " + melee.dmgPerHit.ToString();
        }
        
    }

    public void SetSecondary()
    {
        if (unitType == UnitType.RANGED)
        {
            secondary.text = "Debuff: " + ranged.debuff.name;
        }

        if (unitType == UnitType.MELEE)
        {
            secondary.text = "Debuff: " + melee.debuff.name;
        }
    }

    public void Sell()
    {
        if(unitType == UnitType.MELEE)
        {
            target.turret.GetComponent<Melee>().RemoveBlocked();
        }
        target.SellTurret();
        BuildManager.instance.DeselectNode();
        target = null;
    }

    public void SetSell()
    {
        price.text = turretBlueprint.GetSellAmount().ToString() + " DP";
    }

    public Node GetTarget()
    {
        return target;
    }
}
