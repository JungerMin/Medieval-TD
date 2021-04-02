using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColour;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color startColour;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! -  TODO: Display on screen.");
            return;
        }

        // Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColour;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
