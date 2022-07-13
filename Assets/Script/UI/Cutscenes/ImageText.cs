using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ImageText", menuName = "CreateText")]
public class ImageText : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _text;
    [SerializeField] private int _spriteNumber;

    public Sprite Sprite => _sprite;
    public string Text => _text;
    public int SpriteNumber => _spriteNumber;

}
