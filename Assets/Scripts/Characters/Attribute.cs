using UnityEngine;

[CreateAssetMenu(fileName = "NewAttribute", menuName = "Character/Attribute")]
public class Attribute : ScriptableObject
{
    public string attributeName;     
    public Sprite attributeIcon;      
}