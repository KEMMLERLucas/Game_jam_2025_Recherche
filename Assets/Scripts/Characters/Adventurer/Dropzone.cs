using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item dropped in: " + gameObject.name);

        // Récupère la carte draguée
        AdventurerDisplay droppedCard = eventData.pointerDrag.GetComponent<AdventurerDisplay>();

        if (droppedCard != null)
        {
            droppedCard.transform.SetParent(transform, false);
            droppedCard.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
      public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovering over Party Zone");
        // Ajouter changement couleur
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Left Party Zone");
        // Remettre la couleur normale
    }
}
