using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<Image> slots = new List<Image>();
    public void SetInventory()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (PlayerController.items.Count > i)
            {
                slots[i].sprite = PlayerController.items[i].icon;
                slots[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                slots[i].sprite = null;
                slots[i].color = new Color(1, 1, 1, 0);
            }
        }
    }
}
