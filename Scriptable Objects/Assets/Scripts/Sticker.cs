using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sticker", menuName = "Sticker")]
public class Sticker : ScriptableObject
{
    public string StickerName;
    public Texture Picture;
    public int Attack;
    public int Defense;
}
