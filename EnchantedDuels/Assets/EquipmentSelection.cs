using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelection : MonoBehaviour
{
    public InventoryManager im;
    public Equipment[] inventory;
    public Transform itemSelection;
    public GameObject itemSelectionPrefab;
    public TMP_Text selectedItem;

    public bool isWeapon;

    public void OnEnable()
    {
        KillChildren(itemSelection);
        
        if (isWeapon)
            selectedItem.text = "Equipped:\n" + im.character.mainHand.name;
        else
            selectedItem.text = "Equipped:\n" + im.character.wornAmour.name;

        foreach (var item in inventory)
        {
            var newItem = Instantiate(itemSelectionPrefab, itemSelection);
            newItem.transform.GetChild(0).GetComponent<TMP_Text>().text = "Select " + item.name;
            newItem.GetComponent<Button>().onClick.AddListener(() => SelectEquipment(item));
        }
    }

    private void SelectEquipment(Equipment item)
    {
        try
        {
            im.SelectWeapon((Weapon) item);
        }
        catch (InvalidCastException)
        {
            im.SelectArmour((Armour) item);
        }
        selectedItem.text = "Equipped:\n" + item.name;
    }

    private static void KillChildren(Transform transformWithChildren)
    {
        foreach (Transform child in transformWithChildren)
        {
            Destroy(child.gameObject);
        }
    }
}
