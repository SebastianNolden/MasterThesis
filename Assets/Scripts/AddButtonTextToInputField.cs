using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddButtonTextToInputField : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
        

    public void AddTextFromButtonToInputField(string buttonText) {
        if (inputField.text.Length < 4) {
            string text = inputField.text;
            text += buttonText;
            inputField.text = text;
        }
    }

    public void DeleteLastCharacterFromInputField() {
        string text = inputField.text;
        text = text.Substring(0, text.Length - 1);
        inputField.text = text;
    }
}
