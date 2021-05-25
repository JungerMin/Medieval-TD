using UnityEngine;
using UnityEngine.EventSystems;

public class LevelNode : MonoBehaviour
{
    public string[] clearedStage;

    public string thisStage;
    public string previousStage;

    public Color canSelectColor;
    public Color canNotSelectColor;
    public Color hoverColor;
    public Color isSelectedColor;
    public Color clearedColor;

    private bool selectable = false;
    private bool isSelected = false;
    private bool isCleared = false;

    private Renderer rend;
    private LevelSelectManager levelSelectManager;

    void Start()
    {
        rend = GetComponent<Renderer>();

        string clearedStage = PlayerPrefs.GetString("ClearedStage");

        foreach (string stage in this.clearedStage)
        {
            if (stage == clearedStage)
            {
                rend.material.color = clearedColor;
                isCleared = true;
            }
        }

        if (!isCleared)
        {
            if (clearedStage == previousStage)
            {
                selectable = true;
                rend.material.color = canSelectColor;
            }
            else
            {
                rend.material.color = canNotSelectColor;
            }
        }

        levelSelectManager = LevelSelectManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (selectable && !isSelected)
        {
            levelSelectManager.SelectLevel(this);
            return;
        }

        levelSelectManager.DeselectLevel();
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (selectable && !isSelected)
        {
            rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (selectable && !isSelected)
        {
            rend.material.color = canSelectColor;
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Select()
    {
        isSelected = true;
        rend.material.color = isSelectedColor;
    }

    public void Deselect()
    {
        isSelected = false;
        rend.material.color = canSelectColor;
    }

    public string GetLevel()
    {
        return thisStage;
    }
}

