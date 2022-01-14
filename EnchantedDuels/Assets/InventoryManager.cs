using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public CharacterStats character;

    public GameObject weaponPanel;
    public GameObject movePanel;

    public void Awake()
    {
        weaponPanel.SetActive(true);
        movePanel.SetActive(false);
    }

    public void SelectWeapon(Weapon weapon)
    {
        character.mainHand = weapon;
    }

    public void SelectArmour(Armour armour)
    {
        character.wornAmour = armour;
    }

    public void SelectEquipment()
    {
        weaponPanel.SetActive(true);
        movePanel.SetActive(false);
    }

    public void SelectSpells()
    {
        Debug.Log("Button Pressed");
        weaponPanel.SetActive(false);
        Debug.Log("Weapons Disabled");
        movePanel.SetActive(true);
        Debug.Log("Struggling After the fact");
    }

    public void Battle()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
