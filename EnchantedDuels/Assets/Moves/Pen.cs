using UnityEngine;

[CreateAssetMenu(fileName = "NewPenMove", menuName = "Move/Pen", order = 0)]
public class Pen : Move
{
    public int effect;
    public int cost;

    public override string DoMove(Character attacker, Character defender)
    {
        attacker.curEnergy -= cost;

        var oldStr = attacker.curStrength;
        attacker.curStrength += effect;

        return attacker.displayName + " increased their strength from " + oldStr + " to " + attacker.curStrength + " at the cost of " + cost + " mana!";
    }

    public override bool CanDoMove(Character attacker)
    {
        return attacker.curEnergy > cost;
    }
}