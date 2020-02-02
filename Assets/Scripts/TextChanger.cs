using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextChanger : MonoBehaviour
{
    [SerializeField] Text _text;
    
    public void ChangeTextValue(float value)
    {
        _text.text = value.ToString();
    }
}
