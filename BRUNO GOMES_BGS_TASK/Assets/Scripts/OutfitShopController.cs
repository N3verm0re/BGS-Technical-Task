using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutfitShopController : MonoBehaviour
{
    [SerializeField] private InventoryController playerInventory;
    private int currentSelectedOutfitId;
    [SerializeField] private Outfit[] outfitsAvailable;
    [SerializeField] private Image outfitPreview;
    [SerializeField] private TextMeshProUGUI outfitName;
    [SerializeField] private TextMeshProUGUI outfitDescription;
    [SerializeField] private TextMeshProUGUI outfitPrice;
    [SerializeField] private GameObject outfitsPanel;
    [SerializeField] private GameObject itemsPanel;

    public void SelectOutfit(int id)
    {
        if (id >= outfitsAvailable.Length)
        {
            Debug.LogError("outfit id not in shop");
        }

        currentSelectedOutfitId = id;
        outfitPreview.sprite = outfitsAvailable[id].preview;
        outfitName.text = outfitsAvailable[id].name;
        outfitDescription.text = outfitsAvailable[id].description;
        outfitPrice.text = $"Buy - {outfitsAvailable[id].price}";
    }
    public void BuyOutfit()
    {
        if(playerInventory.currencyAvailable >= outfitsAvailable[currentSelectedOutfitId].price)
        {
            playerInventory.currencyAvailable -= outfitsAvailable[currentSelectedOutfitId].price;
            playerInventory.playerOutfits.Add(outfitsAvailable[currentSelectedOutfitId]);
            //Remove outfit from shop
        }
    }
    public void GoToItems()
    {
        itemsPanel.SetActive(true);
        outfitsPanel.SetActive(false);
    }
}
