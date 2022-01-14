using UnityEngine;

[CreateAssetMenu(fileName = "NewHealMove", menuName = "Move/Heal", order = 0)]
public class Heal : Move
{
    public int effect;
    public int cost;

    public override string DoMove(Character attacker, Character defender)
    {
        attacker.curEnergy -= cost;
        
        attacker.curHealth += effect;

        return attacker.displayName + " converted " + cost + " mana to " + effect + " health!";
    }

    public override bool CanDoMove(Character attacker)
    {
        return attacker.curEnergy > cost;
    }
}