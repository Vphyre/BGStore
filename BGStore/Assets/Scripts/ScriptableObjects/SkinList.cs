using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skin
{
    public RuntimeAnimatorController Animator;
    public GameObject SkinPreview;
    public int Cost;
}

[CreateAssetMenu(fileName = "SkinList", menuName = "Skin List")]
public class SkinList : ScriptableObject
{
    public List<Skin> Skins;
}
