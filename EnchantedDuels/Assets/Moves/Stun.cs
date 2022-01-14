using UnityEngine;

[CreateAssetMenu(fileName = "NewStunMove", menuName = "Move/Stun", order = 0)]
public class Stun : Move
{
    [Range(0, 1)]
    public float chance;
    public int maxTurns;
        
    [Header("Damage")]
    public int effect;
    public int cost;

    public override string DoMove(Character attacker, Character defender)
    {
        attacker.curEnergy -= cost;
        
        var damage = (effect + attacker.curStrength);
        // TODO - Get a better random damage than this
        damage = (int) Random.Range(damage * 0.95f, damage * 1.05f);
        var takenDamage = defender.TakeDamage(damage);

        if (!(Random.value > chance))
            return defender.displayName + " took " + takenDamage + " damage from " + attacker.displayName + " at the cost of " +
                   cost + " mana! Unfortunately for them, the stun failed...";
        var turnCount = Random.Range(1, maxTurns + 1); 
        if (defender.stunTimer >= turnCount)
            return defender.displayName + " took " + takenDamage + " damage from " + attacker.displayName + " at the cost of " + cost + " mana!" +
                   " But " + defender.displayName + " was already stunned!";
        if (defender.stunTimer > 0)
        {
            var additionalTurns = turnCount - defender.stunTimer;
            defender.stunTimer += additionalTurns;
            return defender.displayName + " took " + takenDamage + " damage from " + attacker.displayName + " at the cost of " +
                   cost + " mana! " + attacker.displayName + "'s attack was so shocking, it stunned " + defender.displayName
                   + " for an additional " + additionalTurns + " turn(s)!";
        }

        defender.stunTimer = turnCount;
        return defender.displayName + " took " + takenDamage + " damage from " + attacker.displayName + " at the cost of " + cost + " mana! " +
               defender.displayName + " was stunned for " + turnCount + " turn(s)!";
    }

    public override bool CanDoMove(Character attacker)
    {
        return attacker.curEnergy > cost;
    }
}
