using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Character))]
public class CharacterUI : MonoBehaviour
{
    [Header("Player Info")]
    public TMP_Text displayName;
    public Image avatar;
    
    [Header("Stats")]
    public TMP_Text health;
    public TMP_Text mana;
    public TMP_Text strength;
    public TMP_Text defence;
    public TMP_Text speed;

    private Character _character;

    public void Start()
    {
        _character = gameObject.GetComponent<Character>();
        Debug.Log("X:" + _character, this);
        displayName.text += _character.stats.displayName;
        avatar.sprite = _character.stats.avatar;
        UpdateStats();
    }
    
    public void UpdateStats()
    {
        Debug.Log(_character, gameObject);
        Debug.Log(_character.displayName, gameObject);
        health.text = _character.curHealth.ToString();
        mana.text = _character.curEnergy.ToString();
        strength.text = _character.curStrength.ToString();
        defence.text = _character.curDefence.ToString();
        speed.text = _character.curSpeed.ToString();
    }
}
