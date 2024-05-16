using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopController : MonoBehaviour
{
    [SerializeField] private InventoryController playerInventory;
    private int selectedItemId;
    [SerializeField] private Item[] itemsAvailable;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private TextMeshProUGUI itemValue;
    [SerializeField] private GameObject outfitsPanel;
    [SerializeField] private GameObject itemsPanel;    
    public void SelectItem(int id)
    {
        if (id >= itemsAvailable.Length)
        {
            Debug.LogError("item id not in shop");
            return;
        }

        selectedItemId = id;
        itemIcon.sprite = itemsAvailable[id].icon;
        itemName.text = itemsAvailable[id].name;
        itemDescription.text = itemsAvailable[id].description;
        itemPrice.text = $"Buy - {itemsAvailable[id].price}";
        itemValue.text = $"Sell - {itemsAvailable[id].sellValue}";
    }

    public void BuyItem()
    {
        if (playerInventory.currencyAvailable >= itemsAvailable[selectedItemId].price && playerInventory.playerItems.Count < 9)
        {
            playerInventory.playerItems.Add(itemsAvailable[selectedItemId]);
            playerInventory.currencyAvailable -= itemsAvailable[selectedItemId].price;
        }
        else
        {
            //Tell Player he does not have enough currency for item
        }
    }

    public void SellItem()
    {
        bool hasItem = false;
        int i = 0;
        foreach (Item item in playerInventory.playerItems)
        {
            if (item.itemId == itemsAvailable[selectedItemId].itemId) 
            { 
                hasItem = true;
                playerInventory.playerItems.RemoveAt(i);
                break; 
            }
        }

        if (hasItem)
        {
            playerInventory.currencyAvailable += itemsAvailable[selectedItemId].sellValue;
        }
    }

    public void GoToOutfits()
    {
        outfitsPanel.SetActive(true);
        itemsPanel.SetActive(false);
    }
}
