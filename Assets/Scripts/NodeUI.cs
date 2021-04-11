using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject backPoint;
    public Transform mainCamera;
    public GameObject nodeUI;

    private Node target;

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
}
