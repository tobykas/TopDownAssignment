using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public bool ShopActive = false;

    public List<Items> shopItems;
    public GameObject itemPrefab;
    public Transform itemsParent;

    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public Image itemImage;

    public GameObject congratsBuyText;
    public GameObject deniedBuyText;
    public GameObject closeButton;

    private Items selectedItem;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private InventoryManager inventory;

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

                // Identify the OnButtonClick
                itemScript.itemButton.onClick.AddListener(itemScript.OnButtonClick);

                //Reference to the ShopSystem for the prefabs
                itemScript.SetShopManager(this);
                itemScript.SetAssociatedItem(item);
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
        itemName.text = item.itemName;
        itemPrice.text = "Price: " + item.price.ToString();
        itemImage.sprite = item.itemSprite;
    }

    public void BuyItem()
    {
        if (selectedItem != null)
        {
            // Implement logic to deduct currency
            playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
            if (playerManager != null) 
            {
                if (playerManager.coins >= selectedItem.price)
                {
                    playerManager.coins -= selectedItem.price;
                    congratsBuyText.SetActive(true);
                    Invoke("HideCongratsText", 4.0f);
                    Debug.Log("Item Bought: " + selectedItem.itemName);
                    // add item to player's inventory
                    inventory.AddItem(selectedItem);
                }
                else 
                {
                    deniedBuyText.SetActive(true);
                    Invoke("HideDeniedText", 4.0f);
                    Debug.Log("The player don't have the money");
                }
            }
        }
    }

    public void HideCongratsText() 
    {
        congratsBuyText.SetActive(false);
    }

    public void HideDeniedText() 
    {
        deniedBuyText.SetActive(false);
    }
}
