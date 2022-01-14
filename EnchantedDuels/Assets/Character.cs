using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStats stats;

    public int curHealth;
    public int curEnergy;
    
    public int curDefence;
    public int curStrength;

    public int curSpeed;

    [Header("Effects")]
    public int stunTimer = 0;

    public string displayName;

    public void Awake()
    {
        // Set starting stats
        curHealth = stats.maxHealth;
        curEnergy = stats.maxEnergy;
        curDefence = stats.defence;
        curStrength = stats.strength;
        curSpeed = stats.speed;
        displayName = stats.displayName;
        
        stats.wornAmour.OnEquip(this);
        stats.mainHand.OnEquip(this);
    }
    
    public int TakeDamage(int damage)
    {
        var takenDamage = damage - curDefence;
        curHealth -= takenDamage;

        return takenDamage;
    }

    public bool IsAlive()
    {
        return curHealth > 0 && curEnergy > 0;
    }

    public Move PickMove()
    {
        if (stunTimer > 0)
        {
            stunTimer -= 1;
            BattleManager.Instance.AddText(displayName + " is stunned and can't attack!");
            return null;
        }
        var moveIndex = Random.Range(0, stats.moveSet.Length);
        return stats.moveSet[moveIndex].CanDoMove(this) ? stats.moveSet[moveIndex] : null;
    }
}
