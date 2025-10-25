using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Data")]
    public List<Class> classes; // Liste de tous les ScriptableObjects Class
    public List<Dungeon> dungeons; // Liste de tous les ScriptableObjects Dungeon

    [Header("Managers")]
    public ScoreManager scoreManager;
    public TeamManager teamManager;
    public ClassListManager classListManager; // Gestionnaire de la liste d'aventuriers

    [Header("UI References")]
    public DungeonDisplay dungeonDisplay; // Référence au script DungeonDisplay sur Quest

    [Header("Configuration")]
    public AttributeRoleConfig attributeConfig; // Config pour les attributs

    // Classes disponibles pour cette partie
    private Class availableClass1;
    private Class availableClass2;
    private Class availableClass3;
    private Class availableClass4;

    // Donjon actuel
    private Dungeon currentDungeon;

    void Start()
    {
        LoadRandomDungeon();
        LoadRandomClasses();
    }

    /// <summary>
    /// Charge un donjon aléatoire et l'affiche
    /// </summary>
    public void LoadRandomDungeon()
    {
        if (dungeons == null || dungeons.Count == 0)
        {
            Debug.LogError("No dungeons available in GameManager!");
            return;
        }

        // Sélectionne un donjon aléatoire
        currentDungeon = dungeons[Random.Range(0, dungeons.Count)];

        Debug.Log("Donjon chargé : " + currentDungeon);
        Debug.Log("Donjon chargé : " + currentDungeon.attribute1);

        // Met à jour l'affichage du donjon
        if (dungeonDisplay != null)
        {
            dungeonDisplay.SetDungeon(currentDungeon);
        }
        else
        {
            Debug.LogError("DungeonDisplay not assigned in GameManager!");
        }
    }

    public void LoadRandomClasses()
    {
        if (classes == null || classes.Count == 0)
        {
            Debug.LogError("No classes available in GameManager!");
            return;
        }

        // Génère 4 classes aléatoires
        availableClass1 = classes[Random.Range(0, classes.Count)];
        availableClass2 = classes[Random.Range(0, classes.Count)];
        availableClass3 = classes[Random.Range(0, classes.Count)];
        availableClass4 = classes[Random.Range(0, classes.Count)];

        Debug.Log($"Classes chargées : {availableClass1.ClassName}, {availableClass2.ClassName}, {availableClass3.ClassName}, {availableClass4.ClassName}");

        // Instancie les cartes dans la liste via le ClassListManager
        if (classListManager != null)
        {
            classListManager.ClearList();
            classListManager.AddCard(availableClass1);
            classListManager.AddCard(availableClass2);
            classListManager.AddCard(availableClass3);
            classListManager.AddCard(availableClass4);
        }
        else
        {
            Debug.LogError("ClassListManager not assigned in GameManager!");
        }
    }

    /// <summary>
    /// Valide la sélection d'équipe et calcule le score
    /// </summary>
    public void ResolveTeamSelection()
    {
    
    }

    /// <summary>
    /// Recharge un nouveau donjon (pour bouton "Next Dungeon")
    /// </summary>
    public void NextDungeon()
    {
        LoadRandomDungeon();
    }

    /// <summary>
    /// Recharge de nouvelles classes (pour bouton "Refresh Classes")
    /// </summary>
    public void RefreshClasses()
    {
        LoadRandomClasses();
    }
}
