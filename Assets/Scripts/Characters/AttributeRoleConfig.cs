using UnityEngine;

[CreateAssetMenu(fileName = "AttributeRoleConfig", menuName = "Config/AttributeRoleConfig")]
public class AttributeRoleConfig : ScriptableObject
{
    [System.Serializable]
    public struct AttributeLogo
    {
        public Attribute attribute;
        public Sprite logo;
    }

    [System.Serializable]
    public struct RoleLogo
    {
        public Role role;
        public Sprite logo;
    }

    public AttributeLogo[] attributeLogos;
    public RoleLogo[] roleLogos;

    public Sprite GetLogoForAttribute(Attribute attribute)
    {
        foreach (var mapping in attributeLogos)
        {
            if (mapping.attribute == attribute)
            {
                return mapping.logo;
            }
        }

        Debug.LogWarning($"No logo found for attribute: {attribute}");
        return null;
    }
}