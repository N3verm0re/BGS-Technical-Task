using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Outfit", menuName = "ScriptableObjects/Outfit", order = 1)]
public class Outfit : ScriptableObject
{
    public new string name;
    public int outfitId;
    public string description;
    public GameObject prefab;
    public Sprite preview;
    public int price;
}
