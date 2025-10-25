using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttributeDisplay : MonoBehaviour
{
    [Header("UI Elements")]
    public Image attributeIcon;
    public TextMeshProUGUI attributeName;

    [Header("Configuration")]
    public AttributeRoleConfig attributeConfig;

    /// <summary>
    /// Affiche un attribut (enum) avec son icône et son nom
    /// </summary>
    public void SetAttribute(Attribute attribute)
    {
        gameObject.SetActive(true);

    
        if (attributeName != null)
        {
            attributeName.text = attribute.ToString(); 
        }
        if (attributeIcon != null && attributeConfig != null)
        {
            Sprite logo = attributeConfig.GetLogoForAttribute(attribute);
            if (logo != null)
            {
                attributeIcon.sprite = logo;
            }
            else
            {
                Debug.LogWarning($"No sprite found for attribute: {attribute}");
            }
        }
    }

    /// <summary>
    /// Affiche un attribut avec une config spécifique
    /// </summary>
    public void SetAttribute(Attribute attribute, AttributeRoleConfig config)
    {
        attributeConfig = config;
        SetAttribute(attribute);
    }
}
