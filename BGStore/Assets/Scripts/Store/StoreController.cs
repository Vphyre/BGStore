using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class StoreController : MonoBehaviour
{
    [SerializeField] private SkinList _skinList;
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private GameObject _storeCanvas;
    [SerializeField] private GameObject _skinPreviewReference;
    private GameObject skinObject;
    public UnityEvent OnSuccessfulPurchase;
    public UnityEvent OnSuccessfulSale;
    public UnityEvent OnLackOfMoney;
    public UnityEvent OnSaleRemainingSkin;
    public UnityEvent OnDisableStore;
    private Skin currentSkin;
    private int skinIndex = 0;
    private bool isSalesMode = false;
    private List<Skin> storeSkins;

    void Start()
    {
        if (_skinList.Skins.Count > 1)
        {
            currentSkin = _skinList.Skins[0];
            skinObject = Instantiate(_skinList.Skins[skinIndex].SkinPreview, _skinPreviewReference.transform);
            storeSkins = new List<Skin>(_skinList.Skins);
            _goldText.text = _inventoryController.Gold.ToString();
        }
    }
    public void SetSalesMode(bool value)
    {
        isSalesMode = value;
        ChangeSkin(skinIndex);
    }
    public void Buy()
    {
        if (currentSkin.Cost <= _inventoryController.Gold)
        {
            _inventoryController.Gold -= currentSkin.Cost;
            _goldText.text = _inventoryController.Gold.ToString();
            _inventoryController.InventorySkins.Add(currentSkin);
            storeSkins.Remove(currentSkin);
            OnSuccessfulPurchase.Invoke();
            if (storeSkins.Count == 0)
            {
                OnDisableStore.Invoke();
                return;
            }
            ChangeSkin(skinIndex);
        }
        else
        {
            OnLackOfMoney.Invoke();
        }
    }
    public void Sell()
    {
        if (_inventoryController.InventorySkins.Count == 1)
        {
            OnSaleRemainingSkin.Invoke();
            return;
        }
        _inventoryController.Gold += currentSkin.Cost;
        _goldText.text = _inventoryController.Gold.ToString();
        _inventoryController.InventorySkins.Remove(currentSkin);
        _inventoryController.CheckClothes(currentSkin);
        storeSkins.Add(currentSkin);
        ChangeSkin(skinIndex);
        OnSuccessfulSale.Invoke();
    }
    public void ChangeSkin(int value)
    {
        List<Skin> contextSkins;
        if (isSalesMode)
        {
            contextSkins = new List<Skin>(_inventoryController.InventorySkins);
        }
        else
        {
            contextSkins = new List<Skin>(storeSkins);
        }

        skinIndex += value;
        if (skinIndex >= contextSkins.Count)
        {
            skinIndex = 0;
        }
        else if (skinIndex < 0)
        {
            skinIndex = contextSkins.Count - 1;
        }

        currentSkin = contextSkins[skinIndex];
        Destroy(skinObject);
        skinObject = Instantiate(currentSkin.SkinPreview, _skinPreviewReference.transform);
        _priceText.text = "Price: " + currentSkin.Cost;
    }

}
