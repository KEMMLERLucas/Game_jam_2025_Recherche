using UnityEngine;

[System.Serializable]
public struct RoleIcon
{
    public Role role;
    public Sprite icon;
}

[CreateAssetMenu(fileName = "RoleIconDatabase", menuName = "Scriptable Objects/RoleIconDatabase")]
public class RoleIconDatabase : ScriptableObject
{
    public RoleIcon[] roles;

    public Sprite GetIconFor(Role role)
    {
        if (roles == null) return null;
        for (int i = 0; i < roles.Length; i++)
        {
            if (roles[i].role == role) return roles[i].icon;
        }
        return null;
    }
}