using UnityEngine;

[CreateAssetMenu(fileName = "Dungeon", menuName = "Scriptable Objects/Dungeon")]
public class Dungeon : ScriptableObject
{
    public string dungeonName;
    public Sprite dungeonIcon;
    //public string dungeonDescription;
    public Attribute attribute1;
    public Attribute attribute2;
    public Attribute attribute3;
}
