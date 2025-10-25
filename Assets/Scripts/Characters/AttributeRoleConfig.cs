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
}