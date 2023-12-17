using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSellPrefab : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemNameText;
    public TMP_Text itemQuantityText;
    public Button sellButton;

    [SerializeField] private SellManager sellManager; // Reference to the SellManager script
    [SerializeField] private Items associatedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSellManager(SellManager manager)
    {
        sellManager = manager;
    }

    public void SetAssociatedItem(Items item)
    {
        associatedItem = item;
    }

    public void OnSellButtonClick()
    {
        if (sellManager != null && associatedItem != null)
        {
            sellManager.SellItem();
        }
        else
        {
            Debug.LogWarning("Sell manager or associated item is null.");
        }
    }
}
