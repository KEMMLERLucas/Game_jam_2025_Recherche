using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AdventurerDisplay : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Information personnage")]
    public Class characterClass;

    [Header("UI")]
    public Image classIcon;
    public TextMeshProUGUI className;
    public Transform attributesList;
    public GameObject attributePrefab;

    [Header("Configuration")]
    public AttributeRoleConfig attributeConfig; // Référence au mapping des attributs

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private int originalSiblingIndex;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        
        canvas = GetComponentInParent<Canvas>();
    }

    void Start()
    {
        updateDisplay();
    }

    public void updateDisplay()
    {
        if (characterClass == null) return;
        
        // Affiche l'icône de classe
        if (classIcon != null)
        {
            classIcon.sprite = characterClass.classIcon;
        }

        // Affiche le nom de classe
        if (characterClass.ClassName != null)
        {
            className.text = characterClass.ClassName;
        }
        
        // Nettoie les anciens attributs
        foreach (Transform child in attributesList)
        {
            Destroy(child.gameObject);
        }
        
        // Affiche les nouveaux attributs
        DisplayAttribute(characterClass.attribute1);
        DisplayAttribute(characterClass.attribute2);
        DisplayAttribute(characterClass.attribute3);
    }

    /// <summary>
    /// Affiche un attribut (enum) dans la liste
    /// </summary>
    void DisplayAttribute(Attribute attribute)
    {
        if (attributePrefab == null || attributesList == null)
        {
            Debug.LogError("AttributePrefab or AttributesList not assigned!");
            return;
        }

        // Instancie le prefab d'attribut
        GameObject attrGO = Instantiate(attributePrefab, attributesList);
        AttributeDisplay attrDisplay = attrGO.GetComponent<AttributeDisplay>();

        if (attrDisplay != null)
        {
            // Passe la config au display si elle existe
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
            Debug.LogError("AttributeDisplay component not found on prefab!");
        }
    }

    // Drag & Drop handlers
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BEGIN DRAG: " + characterClass.ClassName);
        
        originalParent = transform.parent;
        originalSiblingIndex = transform.GetSiblingIndex();

        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling(); 
        
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("END DRAG");
        
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == canvas.transform)
        {
            Debug.Log("No valid drop zone, returning to original position");
            transform.SetParent(originalParent, false);
            transform.SetSiblingIndex(originalSiblingIndex);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
