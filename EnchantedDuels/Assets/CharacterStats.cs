using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character", order = 0)]
public class CharacterStats : ScriptableObject
{
    public int maxHealth;

    public int maxEnergy;

    public int defence;
    public int strength;

    public int speed;

    public Move[] moveSet = new Move[4];

    //public GearSet equippedGear;
    public Weapon mainHand;
    public Equipment wornAmour;

    public string displayName;
    public Sprite avatar;
}
