using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPrefab : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemQuantityText;
    public Image itemImage;
    public Button itemButton;

    [SerializeField] private InventoryManager inventoryManager; // Reference to the InventoryManager script
    [SerializeField] private Items associatedItem;

    // Set up the reference to the ShopManager script
    public void SetInventoryManager(InventoryManager manager)
    {
        inventoryManager = manager;
    }

    public void SetAssociatedItem(Items item)
    {
        associatedItem = item;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
