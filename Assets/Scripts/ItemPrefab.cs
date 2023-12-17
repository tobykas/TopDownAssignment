using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPrefab : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemPriceText;
    public Image itemImage;
    public Button itemButton;

    [SerializeField]private ShopSystem shopManager; // Reference to the ShopManager script
    [SerializeField]private Items associatedItem;

    // Set up the reference to the ShopManager script
    public void SetShopManager(ShopSystem manager)
    {
        shopManager = manager;
    }

    public void SetAssociatedItem(Items item) 
    {
        associatedItem = item;
    }

    // Method to be called when the button is clicked
    public void OnButtonClick()
    {
        if (shopManager != null)
        {
            shopManager.SelectItem(associatedItem);
        }
        else 
        {
            Debug.Log("IsNull");
        }
    }

}
