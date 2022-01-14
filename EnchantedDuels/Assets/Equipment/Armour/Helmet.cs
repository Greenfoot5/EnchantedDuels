using UnityEngine;

[CreateAssetMenu(fileName = "NewHelmet", menuName = "Equipment/Armour/Helmet", order = 1)]
public class Helmet : Armour
{
    public int additionalStrength;

    public override void OnEquip(Character character)
    {
        character.curDefence += additionalDefence;
        character.curStrength += additionalStrength;
    }

    public override void OnUnequip(Character character)
    {
        character.curDefence -= additionalDefence;
        character.curStrength -= additionalStrength;
    }
}