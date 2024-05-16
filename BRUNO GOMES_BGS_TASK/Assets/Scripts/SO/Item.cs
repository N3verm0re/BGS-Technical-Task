using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item", order = 1)]

public class Item : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public int price;
    public int sellValue;
}
