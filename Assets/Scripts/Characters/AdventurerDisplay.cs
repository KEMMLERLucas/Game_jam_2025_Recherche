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

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition; 

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
        if (characterClass == null)
        {
            return;
        }
        if (classIcon != null)
        {
            classIcon.sprite = characterClass.classIcon;
        }
        if (characterClass.ClassName != null)
        {
            className.text = characterClass.ClassName;
        }
        foreach (Transform child in attributesList)
        {
            Destroy(child.gameObject);
        }
        //DisplayAttribute(characterClass.attribute1);
        //DisplayAttribute(characterClass.attribute2);
        //DisplayAttribute(characterClass.attribute3);
    }
    /*
    void DisplayAttribute(Attribute attribute)
    {
        if (attribute == null) return;

        GameObject attrGO = Instantiate(attributePrefab, attributesList);
        AttributeDisplay attrDisplay = attrGO.GetComponent<AttributeDisplay>();

        if (attrDisplay != null)
        {
            attrDisplay.SetAttribute(attribute);
        }
    }*/

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.7f;         
        canvasGroup.blocksRaycasts = false;
        Debug.Log("Drag started!"); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("Drag ended!");
        // Pour ramener la carte à sa position d'origine
        // rectTransform.anchoredPosition = originalPosition;
    }
}
