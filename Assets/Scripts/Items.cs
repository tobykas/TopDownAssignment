using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
    public string itemName;
    public Sprite itemSprite;
    public int price;
    public int quantity;

    public Items(string name, Sprite sprite, int priceItem, int quantityItem) 
    {
        itemName = name;
        itemSprite = sprite;
        price = priceItem;
        quantity = quantityItem;
    }
}
