using UnityEngine;

[CreateAssetMenu(fileName = "NewSword", menuName = "Equipment/Weapon/Sword", order = 1)]
public class Sword : Weapon
{
    public int additionalDefence;

    public override void OnEquip(Character character)
    {
        character.curStrength += additionalStrength;
        character.curDefence += additionalDefence;
    }

    public override void OnUnequip(Character character)
    {
        character.curStrength -= additionalStrength;
        character.curDefence -= additionalDefence;
    }
}