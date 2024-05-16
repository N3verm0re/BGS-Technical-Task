using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopController : MonoBehaviour
{
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

        selectedItemId = itemsAvailable[id].itemId;
        itemIcon.sprite = itemsAvailable[id].icon;
        itemName.text = itemsAvailable[id].name;
        itemDescription.text = itemsAvailable[id].description;
        itemPrice.text = $"Buy - {itemsAvailable[id].price}";
        itemPrice.text = $"Sell - {itemsAvailable[id].sellValue}";
    }

    public void BuyItem()
    {
        //if item price < available currency
        //Add item to inventory
        //Deduct price
    }

    public void SellItem()
    {
        //if player has >0 of item
        //Remove item from inventory
        //Add value to currency
    }

    public void GoToOutfits()
    {
        outfitsPanel.SetActive(true);
        itemsPanel.SetActive(false);
    }
}
