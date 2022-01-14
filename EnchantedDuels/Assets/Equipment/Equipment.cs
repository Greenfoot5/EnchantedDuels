using UnityEngine;

public abstract class Equipment : ScriptableObject
{
    public abstract void OnEquip(Character character);

    public abstract void OnUnequip(Character character);
}
