using UnityEngine;

[CreateAssetMenu(fileName = "NewChestplate", menuName = "Equipment/Armour/Chestplate", order = 0)]
public class Chestplate : Armour
{
    public override void OnEquip(Character character)
    {
        character.curDefence += additionalDefence;
    }

    public override void OnUnequip(Character character)
    {
        character.curDefence -= additionalDefence;
    }
}