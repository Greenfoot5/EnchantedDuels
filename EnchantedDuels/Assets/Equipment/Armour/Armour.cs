using UnityEngine;

[CreateAssetMenu(fileName = "NewArmour", menuName = "Equipment/Armour/Empty", order = -1)]
public class Armour : Equipment
{
    public int additionalDefence;

    public override void OnEquip(Character character)
    {
        character.curDefence += additionalDefence;
    }

    public override void OnUnequip(Character character)
    {
        character.curDefence -= additionalDefence;
    }
}