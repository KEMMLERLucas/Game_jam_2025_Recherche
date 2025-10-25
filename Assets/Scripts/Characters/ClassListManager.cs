using UnityEngine;

public class ClassListManager : MonoBehaviour
{
    public Transform contentParent;        // Content du Scroll View
    public GameObject adventurerCardPrefab; // Prefab de carte
    public Class[] availableClasses;       // Liste des classes disponibles

    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        foreach (Class charClass in availableClasses)
        {
            GameObject cardGO = Instantiate(adventurerCardPrefab, contentParent);
            AdventurerDisplay card = cardGO.GetComponent<AdventurerDisplay>();
            card.characterClass = charClass;
            card.updateDisplay();
        }
    }
}
