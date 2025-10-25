using UnityEngine;

[CreateAssetMenu(fileName = "AttributePointsConfig", menuName = "Config/AttributePointsConfig")]
public class AttributePointsConfig : ScriptableObject
{
    [System.Serializable]
    public struct AttributePoints
    {
        public Attribute attribute;
        public int points;
    }

    public AttributePoints[] attributePoints;
}