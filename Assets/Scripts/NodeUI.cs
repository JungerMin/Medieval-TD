using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject nodeUI;

    [Header("UI Position")]
    public GameObject backPoint;
    private Transform mainCamera;

    [Header("Turret Stats")]
    public Text attack;
    public Text secondary;
    public Text price;

    private Node target;
    private Units turret;
    private TurretBlueprint turretBlueprint;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (nodeUI.activeSelf == true)
        {
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

        turret = target.turret.GetComponent<Units>();
        turretBlueprint = target.turretBlueprint;

        SetAttack();
        SetSecondary();
        SetSell();
    }

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        nodeUI.SetActive(true);
    }

    public void Hide()
    {
        nodeUI.SetActive(false);
    }

    public void SetAttack()
    {
        attack.text = "Dmg: " + turret.damage.ToString();
    }

    public void SetSecondary()
    {
        secondary.text = "Debuff: " + turret.debuff.name;
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

    public void SetSell()
    {
        price.text = turretBlueprint.GetSellAmount().ToString() + " DP";
    }
}
