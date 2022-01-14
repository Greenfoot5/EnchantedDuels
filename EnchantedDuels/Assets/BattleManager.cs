using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleManager : MonoBehaviour
{
    public const float MoveWait = 3f;
    public const float TurnWait = 2f;
    public static int TurnCount { get; private set; }
    
    public Character[] characters = new Character[2];

    public static BattleManager Instance;
    
    [Header("UI")]
    public Transform content;
    public Scrollbar vScrollbar;
    public GameObject baseText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one BattleManager in the scene!");
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(Battle());
        Random.InitState(5);
    }

    private IEnumerator Battle()
    {
        while (characters[0].IsAlive() && characters[1].IsAlive())
        {
            // Turn Count.
            TurnCount++;
            // Caps turn count, if no damage happens, the duel won't go on forever.
            if (TurnCount >= 100)
                break;
            
            // Display the turn and add mana
            foreach (var character in characters)
            {
                character.curEnergy += 5;
                if (character.curEnergy > character.stats.maxEnergy)
                    character.curEnergy = character.stats.maxEnergy;
            }
            AddText("<style=\"Turn\">Turn " + TurnCount + ".</style> Both players gained 5 mana");

            int first;
            int second;

            if (characters[0].curSpeed > characters[1].curSpeed)
            {
                first = 0;
                second = 1;
            }
            else if (characters[0].curSpeed < characters[1].curSpeed)
            {
                first = 1;
                second = 0;
            }
            else
            {
                first = Random.Range(0, 2);
                second = 1 - first;
            }

            yield return new WaitForSeconds(MoveWait);
            
            // 1st character takes turn
            TakeTurn(first);
            
            // Check if 1st character died
            if (!characters[first].IsAlive())
            {
                continue;
            }
            // Check if 2nd character died
            if (!characters[second].IsAlive())
            {
                continue;
            }

            yield return new WaitForSeconds(MoveWait);
            TakeTurn(second);
            
            // Check if 1st character died
            if (!characters[first].IsAlive())
            {
                continue;
            }
            // Check if 2nd character died
            if (!characters[second].IsAlive())
            {
                continue;
            }

            yield return new WaitForSeconds(TurnWait);
        }

        if (characters[0].IsAlive())
        {
            AddText(characters[0].displayName + " wins!");
        }
        else
        {
            AddText(characters[1].displayName + " wins!");
        }
    }

    private void TakeTurn(int index)
    {
        var chosenMove = characters[index].PickMove();
        if (chosenMove == null)
        {
            AddText(characters[index].displayName + " couldn't attack!");
            return;
        }
        var stringToDisplay = chosenMove.DoMove(characters[index], characters[1 - index]);
        AddText(stringToDisplay);
        
    }

    public void AddText(string text)
    {
        characters[0].GetComponent<CharacterUI>().UpdateStats();
        characters[1].GetComponent<CharacterUI>().UpdateStats();
        
        // Instantiate a new text object.
        // Transform doesn't matter as a layout component of content does that
        var position = new Vector3(0f, 0f, 0f);
        var rotation = new Quaternion(0f, 0f, 0f, 0f);
        var newText = Instantiate(baseText, position, rotation, content);

        // Get the text part of the TMP Object and set it to the desired value.
        var textComponent = newText.GetComponent<TMP_Text>();
        textComponent.text = text;
    }

    public void EditEquipment()
    {
        SceneManager.LoadScene("Setup");
    }
}
