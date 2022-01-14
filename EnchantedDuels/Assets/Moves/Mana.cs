using UnityEngine;

[CreateAssetMenu(fileName = "NewManaMove", menuName = "Move/Mana", order = 0)]
public class Mana : Move
{
    public int effect;
    public int cost;

    public override string DoMove(Character attacker, Character defender)
    {
        attacker.curHealth -= cost;
        
        attacker.curEnergy += effect;

        return attacker.displayName + " converted " + cost + " health to " + effect + " mana!";
    }

    public override bool CanDoMove(Character attacker)
    {
        return attacker.curEnergy > cost;
    }
}