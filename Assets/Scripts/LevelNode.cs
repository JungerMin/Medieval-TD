using UnityEngine;
using UnityEngine.EventSystems;

public class LevelNode : MonoBehaviour
{
    public Color canSelectColor;
    public Color canNotSelectColor;
    public Color hoverColor;
    public Color isSelectedColor;
    public Color clearedColor;

    public int levelNumber;

    public int previousLevel;

    public string levelName;

    private bool selectable = false;
    private bool isSelected = false;

    private Renderer rend;
    private LevelSelectManager levelSelectManager;

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
        return levelName;
    }
}
