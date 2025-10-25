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

    /*void DisplayAttribute(Attribute attribute)
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
