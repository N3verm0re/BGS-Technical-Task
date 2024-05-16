using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitSelector : MonoBehaviour
{
    [SerializeField] private InventoryController playerInventory;

    public void SelectOutfit(int outfitId)
    {
        ///Delete previous outfit
        Destroy(this.GetComponentInChildren<Transform>().gameObject);

        GameObject newOutfit = Instantiate(playerInventory.playerOutfits[outfitId].prefab);
        newOutfit.transform.parent = transform;
    }
}
