using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<Class> selectedClasses;
    public Dungeon currentdungeon;
    public TextMeshProUGUI scoreText;

    Class selectedClass1;
    Class selectedClass2;
    Class selectedClass3;
    Class selectedClass4;

    bool validateDungeonAttribute1 = false;
    bool validateDungeonAttribute2 = false;
    bool validateDungeonAttribute3 = false;



    int score;
    int currentScore;
    void Start()
    {
        score = 0;

    }

   public void OnTeamSelectionResolution()
    {
        
        // check currentDungeon attribute 1
        if (currentdungeon.attribute1 == selectedClass1.attribute1 
            || currentdungeon.attribute1 == selectedClass1.attribute2 
            || currentdungeon.attribute1 == selectedClass1.attribute3)
            validateDungeonAttribute1 |= true;
        
        else if (currentdungeon.attribute1 == selectedClass2.attribute1
            || currentdungeon.attribute1 == selectedClass2.attribute2
            || currentdungeon.attribute1 == selectedClass2.attribute3)
            validateDungeonAttribute1 |= true;

        else if (currentdungeon.attribute1 == selectedClass3.attribute1
            || currentdungeon.attribute1 == selectedClass3.attribute2
            || currentdungeon.attribute1 == selectedClass3.attribute3)
            validateDungeonAttribute1 |= true;

        else if (currentdungeon.attribute1 == selectedClass4.attribute1
            || currentdungeon.attribute1 == selectedClass4.attribute2
            || currentdungeon.attribute1 == selectedClass4.attribute3)
            validateDungeonAttribute1 |= true;
        else validateDungeonAttribute1 = false;

        // check currentDungeon attribute 2
        if (currentdungeon.attribute2 == selectedClass1.attribute1
            || currentdungeon.attribute2 == selectedClass1.attribute2
            || currentdungeon.attribute2 == selectedClass1.attribute3)
            validateDungeonAttribute2 |= true;

        else if (currentdungeon.attribute2 == selectedClass2.attribute1
            || currentdungeon.attribute2 == selectedClass2.attribute2
            || currentdungeon.attribute2 == selectedClass2.attribute3)
            validateDungeonAttribute2 |= true;

        else if (currentdungeon.attribute2 == selectedClass3.attribute1
            || currentdungeon.attribute2 == selectedClass3.attribute2
            || currentdungeon.attribute2 == selectedClass3.attribute3)
            validateDungeonAttribute2 |= true;

        else if (currentdungeon.attribute2 == selectedClass4.attribute1
            || currentdungeon.attribute2 == selectedClass4.attribute2
            || currentdungeon.attribute2 == selectedClass4.attribute3)
            validateDungeonAttribute2 |= true;
        else validateDungeonAttribute2 = false;

        // check currentDungeon attribute 3
        if (currentdungeon.attribute3 == selectedClass1.attribute1
            || currentdungeon.attribute3 == selectedClass1.attribute2
            || currentdungeon.attribute3 == selectedClass1.attribute3)
            validateDungeonAttribute3 |= true;

        else if (currentdungeon.attribute3 == selectedClass2.attribute1
            || currentdungeon.attribute3 == selectedClass2.attribute2
            || currentdungeon.attribute3 == selectedClass2.attribute3)
            validateDungeonAttribute3 |= true;

        else if (currentdungeon.attribute3 == selectedClass3.attribute1
            || currentdungeon.attribute3 == selectedClass3.attribute2
            || currentdungeon.attribute3 == selectedClass3.attribute3)
            validateDungeonAttribute3 |= true;

        else if (currentdungeon.attribute3 == selectedClass4.attribute1
            || currentdungeon.attribute3 == selectedClass4.attribute2
            || currentdungeon.attribute3 == selectedClass4.attribute3)
            validateDungeonAttribute3 |= true;
        else validateDungeonAttribute3 = false;



        score = currentScore;
        scoreText.text = "score : " + score;
    }

}
