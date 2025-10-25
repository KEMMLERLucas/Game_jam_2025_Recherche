using System.ComponentModel;

using UnityEngine;

<<<<<<< Updated upstream
[CreateAssetMenu(fileName = "NewAttribute", menuName = "Character/Attribute")]
public class Attribute : ScriptableObject
{
    public string attributeName;     
    public Sprite attributeIcon;      
}
=======
public enum Attribute
{
    Melee,
    Spellcaster,
    Versatile,
    Fire,
    Frost,
    Thunder,
    Holy,
    Shadow,
    Pets,
    CrowdControl,
    Support,
    AreaOfEffect,
    Agile
}
>>>>>>> Stashed changes
