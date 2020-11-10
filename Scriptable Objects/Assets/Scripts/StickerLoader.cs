using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StickerLoader : MonoBehaviour
{
    [SerializeField]
    Sticker MySticker;

    [SerializeField]
    RawImage PictureControl;

    [SerializeField]
    Text NameControl;

    [SerializeField]
    Text AttackControl;

    [SerializeField]
    Text DefenseControl;

    private void Start()
    {
        NameControl.text = MySticker.StickerName;
        PictureControl.texture = MySticker.Picture;
        AttackControl.text = MySticker.Attack.ToString();
        DefenseControl.text = MySticker.Defense.ToString();
    }
}
