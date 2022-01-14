using UnityEngine;

[CreateAssetMenu(fileName = "NewDamageMove", menuName = "Move/Damage", order = 0)]
public class Damage : Move
{
    public int effect;
    public int cost;

    public override string DoMove(Character attacker, Character defender)
    {
        attacker.curEnergy -= cost;
        
        var damage = (effect + attacker.curStrength);
        // TODO - Get a better random damage than this
        damage = (int) Random.Range(damage * 0.95f, damage * 1.05f);
        var takenDamage = defender.TakeDamage(damage);

        return defender.displayName + " took " + takenDamage + " damage from " + attacker.displayName + " at the cost of " + cost + " mana!";
    }

    public override bool CanDoMove(Character attacker)
    {
        return attacker.curEnergy > cost;
    }
}
