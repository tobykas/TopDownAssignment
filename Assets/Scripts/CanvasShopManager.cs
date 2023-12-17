using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShopManager : MonoBehaviour
{
    public DialogManager dialogManager;
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogManager.enableShopUI)
        {
            shopUI.SetActive(true);
        }
    }
}
