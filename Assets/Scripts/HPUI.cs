using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Text hpText;

    private void Update()
    {
        hpText.text = "HP: " + PlayerStats.Lives.ToString();
    }
}
