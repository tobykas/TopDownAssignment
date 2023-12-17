using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private TMP_Text DialogText;
    [SerializeField, TextArea(4, 10)] private string[] DialogLines;

    public GameObject DialogOptions;

    public float typingTime = 0.35f;
    public bool isDialogActive = false;
    public bool isPlayerInRange = false;
    public bool enableShopUI = false;
    public bool enableSellUI = false;

    public ShopSystem shopSystem;
    public SellManager sellManager;
    public GameObject shopContainer;
    public GameObject sellContainer;

    public void PressKeyToStart()
    {
        if (isPlayerInRange)
        {
            if (!isDialogActive)
            {
                if (shopSystem.ShopActive == false && sellManager.SellActive == false) 
                {
                    ActivateDialog();
                }
            }
        }
    }

    public void ActivateDialog()
    {
        isDialogActive = true;
        DialogPanel.SetActive(true); // Para que se pueda ver

        DialogText.text = string.Empty;
        //StartCoroutine(ShowLine());

        DialogText.text = DialogLines[0];

        DialogOptions.SetActive(true);

    }

    public void DisableDialog()
    {
        isDialogActive = false;
        DialogPanel.SetActive(false);
    }

    private IEnumerator ShowLine()
    {
        DialogText.text = string.Empty;
        foreach (char ch in DialogLines[0])
        {
            DialogText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        DisableDialog();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void WaitActivation()
    {
        if (Input.GetKey(KeyCode.F))
        {
            enableSellUI = true;
            if (sellManager.SellActive == false) 
            {
                sellManager.SellActive = true;
                sellContainer.SetActive(true);
                sellManager.OpenSellUI();
                sellManager.closeButton.SetActive(true);
                DialogPanel.SetActive(false);
                DialogOptions.SetActive(false);
                isDialogActive = false;
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            enableShopUI = true;
            if (shopSystem.ShopActive == false) 
            {
                shopSystem.ShopActive = true;
                shopContainer.SetActive(true);
                shopSystem.closeButton.SetActive(true);
                DialogPanel.SetActive(false);
                DialogOptions.SetActive(false);
                isDialogActive = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            if (isDialogActive)
            {
                Invoke("WaitActivation", 1.0f);
            }

            if (Input.GetKey(KeyCode.E))
            {
                PressKeyToStart();
            }
        }
    }

    public void CloseShop() 
    {
        enableShopUI = false;
        shopSystem.closeButton.SetActive(false);
        shopSystem.ShopActive = false;
        shopContainer.SetActive(false);
        
    }

    public void CloseSell()
    {
        enableSellUI = false;
        sellManager.closeButton.SetActive(false);
        sellManager.SellActive = false;
        sellContainer.SetActive(false);
    }


}
