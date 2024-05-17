using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private GameObject _skinPreviewReference;
    [SerializeField] private Animator _clothesAnimatior;
    private GameObject skinObject;
    private Skin currentSkin;
    private int skinIndex = 0;
    private int gold;
    public int Gold { get { return gold; } set { gold = value; } }
    private List<Skin> inventorySkins;
    public List<Skin> InventorySkins { get { return inventorySkins; } set { inventorySkins = value; } }

    private void Awake()
    {
        gold = _inventoryData.money;
        currentSkin = _inventoryData.purchasedSkins[skinIndex];
        skinObject = Instantiate(currentSkin.SkinPreview, _skinPreviewReference.transform);
        inventorySkins = new List<Skin>(_inventoryData.purchasedSkins);
    }

    public void ChangeSkin(int value)
    {
        skinIndex += value;
        if (skinIndex >= inventorySkins.Count)
        {
            skinIndex = 0;
        }
        else if (skinIndex < 0)
        {
            skinIndex = inventorySkins.Count - 1;
        }

        currentSkin = inventorySkins[skinIndex];
        Destroy(skinObject);
        skinObject = Instantiate(currentSkin.SkinPreview, _skinPreviewReference.transform);
    }
    public void WearClothes()
    {
        _clothesAnimatior.runtimeAnimatorController = currentSkin.Animator;
    }
    public void WearDefaultClothes()
    {
        _clothesAnimatior.runtimeAnimatorController = inventorySkins[0].Animator;
    }
    public void CheckClothes(Skin skin)
    {
        if(inventorySkins.Count == 1 || _clothesAnimatior.runtimeAnimatorController == skin.Animator)
        {
            WearDefaultClothes();
        }
        ChangeSkin(skinIndex);
    }
}
