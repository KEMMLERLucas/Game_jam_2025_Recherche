using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DungeonDisplay : MonoBehaviour
{
    [Header("Dungeon Information")]
    public Dungeon dungeon;

    [Header("UI Elements")]
    public Image dungeonIcon;
    public TextMeshProUGUI dungeonName;
    public TextMeshProUGUI dungeonDescription;
    public Transform attributesList;
    public GameObject attributePrefab;

    [Header("Configuration")]
    public AttributeRoleConfig attributeConfig; // Référence au mapping des attributs

    void Start()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (dungeon == null)
        {
            Debug.LogWarning("No dungeon assigned to DungeonDisplay!");
            return;
        }

        if (dungeonIcon != null && dungeon.dungeonIcon != null)
        {
            dungeonIcon.sprite = dungeon.dungeonIcon;
        }

        if (dungeonName != null)
        {
            dungeonName.text = dungeon.dungeonName;
        }

        // Nettoie les anciens attributs
        ClearAttributes();

        // Affiche les nouveaux attributs
        DisplayAttribute(dungeon.attribute1);
        DisplayAttribute(dungeon.attribute2);
        DisplayAttribute(dungeon.attribute3);
    }

    void DisplayAttribute(Attribute attribute)
    {
        if (attributePrefab == null || attributesList == null)
            return;

        GameObject attrGO = Instantiate(attributePrefab, attributesList);
        AttributeDisplay attrDisplay = attrGO.GetComponent<AttributeDisplay>();

        if (attrDisplay != null)
        {
            if (attributeConfig != null)
            {
                attrDisplay.SetAttribute(attribute, attributeConfig);
            }
            else
            {
                attrDisplay.SetAttribute(attribute);
            }
        }
        else
        {
            Debug.LogWarning("AttributeDisplay component not found on prefab!");
        }
    }

    void ClearAttributes()
    {
        if (attributesList == null)
            return;

        foreach (Transform child in attributesList)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetDungeon(Dungeon newDungeon)
    {
        dungeon = newDungeon;
        UpdateDisplay();
    }
}
