using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class ShopSystem : MonoBehaviour
{
    public List<Items> shopItems;
    public GameObject itemPrefab;
    public Transform itemsParent;

    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public Image itemImage;

    private Items selectedItem;

    // Start is called before the first frame update
    void Start()
    {
        PopulateShopUI();
    }

    void PopulateShopUI()
    {
        float xOffset = 100f;
        foreach (Items item in shopItems)
        {
            GameObject itemInstance = Instantiate(itemPrefab, itemsParent);

            RectTransform itemTransform = itemInstance.GetComponent<RectTransform>();
            itemTransform.anchoredPosition = new Vector2(xOffset, itemTransform.anchoredPosition.y);

            ItemPrefab itemScript = itemInstance.GetComponent<ItemPrefab>();

            if (itemScript != null)
            {
                // Assign the values directly to the components in the prefab script
                itemScript.itemNameText.text = item.itemName;
                itemScript.itemPriceText.text = "Price: " + item.price.ToString();
                itemScript.itemImage.sprite = item.itemSprite;

                // Add a click event to the button to select the item
                itemScript.itemButton.onClick.AddListener(() => SelectItem(item));
            }
            else
            {
                Debug.LogError("ItemPrefabScript component not found on item prefab!");
            }
            xOffset += itemTransform.sizeDelta.x;
        }
    }

    void Update()
    {
        

    }

    public void SelectItem(Items item)
    {
        selectedItem = item;
    }

    public void BuyItem()
    {
        if (selectedItem != null)
        {
            // Implement logic to deduct currency and add item to player's inventory
            // Example: if (playerCurrency >= selecteditem.price) { playerInventory.AddItem(selecteditem); playerCurrency -= selecteditem.price; }
            Debug.Log("Item Bought: " + selectedItem.itemName);
        }
    }
}
