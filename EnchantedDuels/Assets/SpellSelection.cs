using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellSelection : MonoBehaviour
{
    public InventoryManager im;

    public Move[] inventory;
    public Transform inventoryContent;
    public GameObject spellItemPrefab;

    public Button[] moveButtons = new Button[4];

    public int selectedButtonIndex = -1;

    public void OnEnable()
    {
        KillChildren(inventoryContent);

        var moveSet = im.character.moveSet;
        for (var i = 0; i < im.character.moveSet.Length; i++)
        {
            moveButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = moveSet[i].name;
            var buttonIndex = i;
            moveButtons[i].onClick.AddListener(() => SelectMoveToSwap(buttonIndex));
        }

        for (var i = 0; i < inventory.Length; i++)
        {
            var newItem = Instantiate(spellItemPrefab, inventoryContent);
            newItem.transform.GetChild(0).GetComponent<TMP_Text>().text = "Select " + inventory[i].name;
            var inventoryIndex = i;
            newItem.GetComponent<Button>().onClick.AddListener(() => SelectSpell(inventoryIndex));
        }
    }

    private void SelectMoveToSwap(int buttonIndex)
    {
        if (selectedButtonIndex >= 0)
        {
            moveButtons[selectedButtonIndex].interactable = true;
        }

        selectedButtonIndex = buttonIndex;
        moveButtons[buttonIndex].interactable = false;
    }

    private void SelectSpell(int inventoryIndex)
    {
        if (selectedButtonIndex < 0) return;
        im.character.moveSet[selectedButtonIndex] = inventory[inventoryIndex];
        moveButtons[selectedButtonIndex].interactable = true;
        moveButtons[selectedButtonIndex].transform.GetChild(0).GetComponent<TMP_Text>().text = inventory[inventoryIndex].name;
    }
    
    private static void KillChildren(Transform transformWithChildren)
    {
        foreach (Transform child in transformWithChildren)
        {
            Destroy(child.gameObject);
        }
    }
}
