using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public int currencyAvailable;
    public List<Item> playerItems;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject inventoryPanel;

    public void AddItem(Item item)
    {
        playerItems.Add(item);
    }

    public void LoadItems()
    {
        ///Unload previous items
        foreach (Transform button in inventoryPanel.GetComponentInChildren<Transform>())
        {
            Destroy(button.gameObject);
        }

        foreach (Item item in playerItems)
        {
            GameObject itemButton = Instantiate(buttonPrefab);
            Image itemImage = itemButton.GetComponentInChildren<Image>();
            itemImage.sprite = item.icon;
        }
    }
}
