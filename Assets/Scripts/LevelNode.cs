using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelNode : MonoBehaviour
{
    public Color canSelectColor;
    public Color canNotSelectColor;
    public Color selectedColor;
    public Color clearedColor;

    public int levelNumber;

    public int previousLevel;

    private bool selectable = false;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        if (levelReached == previousLevel)
        {
            selectable = true;
            rend.material.color = canSelectColor;
        }
        else if (levelReached >= levelNumber)
        {
            rend.material.color = clearedColor;
        }
        else
        {
            rend.material.color = canNotSelectColor;
        }

        
    }

    private void OnMouseDown()
    {
        if (selectable)
        {
            SceneManager.LoadScene(levelNumber);
        }
    }

    private void OnMouseEnter()
    {
        if (selectable)
        {
            rend.material.color = selectedColor;
        }
    }

    private void OnMouseExit()
    {
        if (selectable)
        {
            rend.material.color = canSelectColor;
        }
    }
}
