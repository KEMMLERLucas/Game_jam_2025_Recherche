using UnityEngine;

[CreateAssetMenu(fileName = "Dungeon", menuName = "Scriptable Objects/Dungeon")]
public class Dungeon : ScriptableObject
{
    public string dungeonName;
    public Sprite dungeonIcon;
    public string dungeonDescription;

    [Range(0, 100)]
    public int attribute1 = 10;

    [Range(0, 100)]
    public int attribute2 = 10;

    [Range(0, 100)]
    public int attribute3 = 10;

    [Range(0, 100)]
    public int attribute4 = 10;
}
