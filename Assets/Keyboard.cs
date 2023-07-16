using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keyboard : MonoBehaviour
{
    TouchScreenKeyboard touchScreenKeyboard;
    public Text text;

    public void OpenKeyboard()
    {
        touchScreenKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }


    
    void Update()
    {
        
    }
}
