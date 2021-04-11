using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    public Color notEnoughMoneyColour;
    public Color selectedColour;
    public Color canSelectColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public bool isSelected = false;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColour;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }



        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            if (!buildManager.HasTurret())
            {
                buildManager.DeselectNode();
            }
            return;
        }
        else if (buildManager.CanBuild)
        {
            buildManager.BuildTurretOn(this);
            rend.material.color = startColour;
        }       
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null && !isSelected)
        {
            rend.material.color = canSelectColor;
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColour;
        } else
        {
            rend.material.color = notEnoughMoneyColour;
        }
    }

    private void OnMouseExit()
    {
        if (!isSelected)
        {
            rend.material.color = startColour;
        }
    }

    public void Select()
    {
        isSelected = true;
        rend.material.color = selectedColour;
    }

    public void Deselect()
    {
        isSelected = false;
        rend.material.color = startColour;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
