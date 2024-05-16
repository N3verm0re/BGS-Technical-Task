using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitIdentifier : MonoBehaviour
{
    public int outfitId;
    public OutfitSelector selector;
    public void SelectOutfit()
    {
        selector.SelectOutfit(outfitId);
    }
}
