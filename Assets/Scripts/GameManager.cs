using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Class> classes;
    public List<Dungeon> dungeons;

    [Header("Elements in Unity")]
    public ScoreManager scoremanager;
    public TeamManager teamManager;

    Class availableClass1;
    Class availableClass2;
    Class availableClass3;
    Class availableClass4;

    Dungeon currentDungeon;

    void Start()
    {
        LoadRandomClasses();
        LoadRandomDungeon();
    }

    public void LoadRandomClasses()
    {
        availableClass1 = classes[Random.Range(0, classes.Count)];
        availableClass2 = classes[Random.Range(0, classes.Count)];
        availableClass3 = classes[Random.Range(0, classes.Count)];
        availableClass4 = classes[Random.Range(0, classes.Count)];

        Debug.Log("le personnage 1 est " + availableClass1.name);
    }

    public void LoadRandomDungeon()
    {
        currentDungeon = dungeons[Random.Range(0, dungeons.Count)];
        Debug.Log ("le donjon est" +  currentDungeon.dungeonName);
    }

    public void ResolveTeamSelection()
    {

    }

}
