using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OutfitShopController : MonoBehaviour
{
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

        currentSelectedOutfitId = outfitsAvailable[id].outfitId;
        outfitPreview.sprite = outfitsAvailable[id].preview;
        outfitName.text = outfitsAvailable[id].name;
        outfitDescription.text = outfitsAvailable[id].description;
        outfitPrice.text = $"Buy - {outfitsAvailable[id].price}";
    }
    public void BuyOutfit()
    {
        //if currency > cost
        //add outfit to OutfitSelector
        //remove button from shop
    }
    public void GoToItems()
    {
        itemsPanel.SetActive(true);
        outfitsPanel.SetActive(false);
    }
}
