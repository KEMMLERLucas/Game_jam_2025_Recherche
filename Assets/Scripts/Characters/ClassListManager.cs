using UnityEngine;

public class ClassListManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject adventurerCardPrefab; 
    public Transform contentParent; 
    public AttributeRoleConfig attributeConfig; 

    public void AddCard(Class characterClass)
    {
        if (adventurerCardPrefab == null || contentParent == null)
        {
            Debug.LogError("AdventurerCardPrefab or ContentParent not assigned!");
            return;
        }

      
        GameObject newCard = Instantiate(adventurerCardPrefab, contentParent);
        
   
        AdventurerDisplay display = newCard.GetComponent<AdventurerDisplay>();
        if (display != null)
        {
            display.characterClass = characterClass;
            display.attributeConfig = attributeConfig;
            display.updateDisplay();
        }
        else
        {
            Debug.LogError("AdventurerDisplay component not found on prefab!");
        }
    }

    /// <summary>
    /// Nettoie toutes les cartes de la liste
    /// </summary>
    public void ClearList()
    {
        if (contentParent == null)
            return;

        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
    }
}
