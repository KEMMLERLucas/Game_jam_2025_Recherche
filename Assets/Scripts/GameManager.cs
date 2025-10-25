using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Class> classes;
    public List<Dungeon> dungeons;

    [Header("Elements in Unity")]
    public TextMeshProUGUI className;
    public SpriteRenderer classImage;
    public TextMeshProUGUI dungeonName;
    public TextMeshProUGUI dungeonDescription;
    public SpriteRenderer dungeonIcon;

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
        className.text = availableClass1.name;
        classImage.sprite = availableClass1.classIcon;

        availableClass2 = classes[Random.Range(0, classes.Count)];
        className.text = availableClass1.name;
        classImage.sprite = availableClass1.classIcon;

        availableClass3 = classes[Random.Range(0, classes.Count)];
        className.text = availableClass1.name;
        classImage.sprite = availableClass1.classIcon;

        availableClass4 = classes[Random.Range(0, classes.Count)];
        className.text = availableClass1.name;
        classImage.sprite = availableClass1.classIcon;


        Debug.Log("le personnage 1 est " + availableClass1.name);
    }

    public void LoadRandomDungeon()
    {
        currentDungeon = dungeons[Random.Range(0, dungeons.Count)];
        dungeonName.text = currentDungeon.name;
        //dungeonDescription.text = currentDungeon.text;
        //dungeonIcon.Sprite = currentDungeon.icon;
        Debug.Log ("le donjon est" +  currentDungeon.dungeonName);
    }

    public void ResolveTeamSelection()
    {

    }

}
