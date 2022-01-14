using UnityEngine;

[CreateAssetMenu(fileName = "NewDrainMove", menuName = "Move/Drain", order = 0)]
public class Drain : Move
{
    public int effect;
    
    public override string DoMove(Character attacker, Character defender)
    {
        attacker.curHealth -= effect;
        var damage = (effect);
        // TODO - Get a better random damage than this
        damage = (int) Random.Range(damage * 0.95f, damage * 1.05f);
        defender.curEnergy -= damage;

        return attacker.displayName + " took " + damage + " mana from " + defender.displayName + " at the cost of " + effect + " health!";
    }

    public override bool CanDoMove(Character attacker)
    {
        return attacker.curHealth > effect;
    }
}
