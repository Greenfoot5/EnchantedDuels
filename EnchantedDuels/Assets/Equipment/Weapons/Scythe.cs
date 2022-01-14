using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Equipment/Weapon/Scythe", order = 0)]
public class Scythe : Weapon
{
    public override void OnEquip(Character character)
    {
        character.curStrength += additionalStrength;
    }

    public override void OnUnequip(Character character)
    {
        character.curStrength -= additionalStrength;
    }
}