using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Equipment/Weapon/Empty", order = -1)]
public class Weapon : Equipment
{
    public int additionalStrength;

    public override void OnEquip(Character character)
    {
        character.curStrength += additionalStrength;
    }

    public override void OnUnequip(Character character)
    {
        character.curStrength -= additionalStrength;
    }
}
