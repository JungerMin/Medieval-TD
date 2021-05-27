using UnityEngine;
using UnityEngine.UI;

public class RangeIndicator : MonoBehaviour
{
    public GameObject unit;
    public GameObject rangeIndicator;
    private float range;

    private void Start()
    {
        range = unit.GetComponent<Units>().range;
        rangeIndicator.transform.localScale = new Vector3(range, 1f, range);
    }

    public void SetActive(bool _bool)
    {
        rangeIndicator.SetActive(_bool);
    }
}
