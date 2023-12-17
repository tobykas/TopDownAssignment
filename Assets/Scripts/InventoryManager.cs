using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> inventory = new List<Items>();
    public GameObject slotPrefab;
    public Transform slotsParent;
    public GameObject spawnHat;
    public GameObject spawnAxe;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        float xOffset = 0f;

        // Clear existing slots
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        // Create slots for each item in the inventory
        foreach (Items item in inventory)
        {
            Debug.Log("Creating slot for: " + item.itemName);

            GameObject slot = Instantiate(slotPrefab, slotsParent);

            RectTransform slotTransform = slot.GetComponent<RectTransform>();
            slotTransform.anchoredPosition = new Vector2(xOffset, slotTransform.anchoredPosition.y);

            InventoryPrefab inventoryScript = slot.GetComponent<InventoryPrefab>();

            if (inventoryScript != null)
            {
                inventoryScript.itemNameText.text = item.itemName;
                inventoryScript.itemQuantityText.text = item.quantity.ToString();
                inventoryScript.itemImage.sprite = item.itemSprite;

                inventoryScript.itemButton.onClick.AddListener(() => ActiveObject(item));

                inventoryScript.SetInventoryManager(this);
                inventoryScript.SetAssociatedItem(item);
            }
            xOffset += slotTransform.sizeDelta.x;
        }
    }

    void OnItemClick(Items clickedItem)
    {
        // Handle item click logic here
        Debug.Log("Clicked on item: " + clickedItem.itemName);
    }

    // Example method to add an item to the inventory
    public void AddItem(Items newItem)
    {
        Items existingItem = inventory.Find(item => item.itemName == newItem.itemName);

        if (existingItem != null)
        {
            // Item already in the inventory, increase quantity
            existingItem.quantity += newItem.quantity;
        }
        else
        {
            // Item not in the inventory, add it
            inventory.Add(newItem);
        }

        // Update the UI after modifying the inventory
        UpdateUI();
    }

    public void RemoveItem(Items item) 
    {
        // Find the index of the item in the inventory
        int index = inventory.FindIndex(i => i == item);

        // Check if the item is in the inventory
        if (index != -1)
        {
            Items existingItem = inventory[index];

            // Check the quantity of the item
            if (existingItem.quantity > 1)
            {
                // If the quantity is greater than 1, reduce it by 1
                existingItem.quantity--;
            }
            else
            {
                // If the quantity is 1, remove the item from the inventory
                if (item.itemName == "Hat") 
                {
                    spawnHat.SetActive(false);
                }
                if (item.itemName == "Axe") 
                {
                    spawnAxe.SetActive(false);
                }
                inventory.RemoveAt(index);
                DestroySlotUI(index);
            }

            // Update the UI after modifying the inventory
            UpdateUI();
        }
        else
        {
            Debug.LogWarning("Item not found in the inventory.");
        }
    }

    void DestroySlotUI(int index)
    {
        // Find the corresponding UI element at the specified index
        Transform slotTransform = slotsParent.GetChild(index);

        // Destroy the UI element
        Destroy(slotTransform.gameObject);
    }

    public void ActiveObject(Items clickedItem) 
    {
        if (clickedItem.itemName == "Hat")
        {
            // Activate the hat spawn object
            spawnHat.SetActive(true);
        }
        else if (clickedItem.itemName == "Axe")
        {
            // Activate the axe spawn object
            spawnAxe.SetActive(true);
        }
    }
}
