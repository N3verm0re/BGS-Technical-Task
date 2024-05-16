using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InventoryController : MonoBehaviour
{
    public int currencyAvailable;
    public List<Item> playerItems;
    public List<Outfit> playerOutfits;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject outfitButtonPrefab;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject outfitPanel;
    private UnityEvent outfitButtonCall;
    private OutfitSelector outfitSelector;
    [SerializeField] private TextMeshProUGUI currencyText;

    private void Update()
    {
        currencyText.text = $"{currencyAvailable}";
    }

    public void AddItem(Item item)
    {
        playerItems.Add(item);
    }

    public void LoadItems()
    {
        ///Unload previous items
        foreach (Transform button in inventoryPanel.GetComponentsInChildren<Transform>())
        {
            Destroy(button.gameObject);
        }

        foreach (Item item in playerItems)
        {
            GameObject itemButton = Instantiate(buttonPrefab);
            Image itemImage = itemButton.GetComponentInChildren<Image>();
            itemImage.sprite = item.icon;
            itemButton.transform.SetParent(inventoryPanel.transform);
        }
    }

    public void LoadOutfits()
    {
        ///Unload previous outfits
        foreach (Transform button in outfitPanel.GetComponentsInChildren<Transform>())
        {
            Destroy(button.gameObject);
        }

        int i = 0;
        foreach (Outfit outfit in playerOutfits)
        {
            GameObject outfitButton = Instantiate(outfitButtonPrefab);
            Image outfitImage = outfitButton.GetComponentInChildren<Image>();
            outfitImage.sprite = outfit.preview;
            outfitButton.GetComponent<OutfitIdentifier>().outfitId = i;
            outfitButton.transform.SetParent(outfitPanel.transform);
            i++;
        }
    }
}
