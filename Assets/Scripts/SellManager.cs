using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellManager : MonoBehaviour
{
    public bool SellActive = false;

    [SerializeField] private InventoryManager inventoryManager;
    public List<Items> inventory;
    public GameObject itemPrefab;
    public Transform itemsParent;
    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text itemQuantity;
    public TMP_Text itemPrice;
    public GameObject sellConfirmationPanel;
    public GameObject closeButton;

    public GameObject congratsSellText;

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Items selectedInventoryItem;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryManager>();
        PopulateSellUI();
    }

    public void PopulateSellUI() 
    {
        if (inventoryManager != null) 
        {
            inventory = inventoryManager.inventory;
        }
        float xOffset = 100f;

        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Items item in inventory)
        {
            GameObject itemInstance = Instantiate(itemPrefab, itemsParent);

            RectTransform itemTransform = itemInstance.GetComponent<RectTransform>();
            itemTransform.anchoredPosition = new Vector2(xOffset, itemTransform.anchoredPosition.y);

            ItemSellPrefab itemScript = itemInstance.GetComponent<ItemSellPrefab>();

            if (itemScript != null)
            {
                // Assign the values directly to the components in the prefab script
                itemScript.itemNameText.text = item.itemName;
                itemScript.itemQuantityText.text = item.quantity.ToString();
                itemScript.itemImage.sprite = item.itemSprite;

                // Identify the OnButtonClick
                itemScript.sellButton.onClick.AddListener(() => SelectInventoryItem(item));

                //Reference to the SellManager for the prefabs
                itemScript.SetSellManager(this);
                itemScript.SetAssociatedItem(item);
            }
            else
            {
                Debug.LogError("ItemPrefabScript component not found on item prefab!");
            }
            xOffset += itemTransform.sizeDelta.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SelectInventoryItem(Items item)
    {
        selectedInventoryItem = item;
        itemName.text = item.itemName;
        itemImage.sprite = item.itemSprite;
        itemQuantity.text = "Quantity: " + item.quantity.ToString();
        itemPrice.text = "Price: " + item.price.ToString();
    }

    public void OpenSellUI()
    {
        PopulateSellUI();
    }

    public void SellItem()
    {
        if (selectedInventoryItem != null)
        {
            playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            playerManager.coins += selectedInventoryItem.price;
            congratsSellText.SetActive(true);
            Invoke("HideCongratsText", 4.0f);
            Debug.Log("Item Bought: " + selectedInventoryItem.itemName);

            inventoryManager.RemoveItem(selectedInventoryItem);

            ResetSelectedInventoryItem();
            PopulateSellUI();
        }
        else
        {
            Debug.LogWarning("No item selected for selling.");
        }
    }
    public void ResetSelectedInventoryItem() 
    {
        selectedInventoryItem = null;
        itemName.text = null;
        itemImage.sprite = null;
        itemQuantity.text = null;
        itemPrice.text = null;
    }
}
