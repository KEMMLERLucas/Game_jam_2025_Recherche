using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<Class> group;
    public Dungeon currentdungeon;
    public TextMeshProUGUI scoreText;
    public int validAttributeScore = 50;

    List<bool> attributeValidList = new List<bool>();
    List<Attribute> dungeonAttributeList = new List<Attribute>();
    //int score;
    int currentScore;
    void Start()
    {
        //score = 0;

    }

   public void AttributeCheck(List<Class> group)
    {
        int i = 0;
        dungeonAttributeList.Add(currentdungeon.attribute1);
        dungeonAttributeList.Add(currentdungeon.attribute2);
        dungeonAttributeList.Add(currentdungeon.attribute3);
        foreach (Attribute a in dungeonAttributeList)
        {
            foreach(Class c in group)
            {
                if(a == c.attribute1 || a == c.attribute2 || a == c.attribute3)
                {
                    attributeValidList[i] = true;
                }
            }
        }
    }

    public void GroupComp(List<Class> group)
    {
        bool tank = false;
        bool healer = false;
        int dpsCount = 0;
        foreach (Class c in group)
        {
            if (c.classRole == Role.Tank)
            {
                tank = true;
            }
            else if (c.classRole == Role.Healer)
            {
                healer = true;
            }
            else if (c.classRole == Role.DPS)
            {
                dpsCount++;
            }
        }
        if (tank && healer && dpsCount >= 3)
        {
            currentScore += 50;
        }
    }

    public void CalculScore()
    {
        foreach (bool b in attributeValidList)
        {
            if (b)
                currentScore += 20;
        }
        scoreText.text = "score : " + currentScore;

    }
}
