using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory", order = 52)]
public class InventoryData : ScriptableObject
{
    public List<Skin> purchasedSkins;
    public int money;
}
