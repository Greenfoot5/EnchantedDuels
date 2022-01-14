using UnityEngine;

public abstract class Move : ScriptableObject
{
    public abstract string DoMove(Character attacker, Character defender);

    public abstract bool CanDoMove(Character attacker);
}
