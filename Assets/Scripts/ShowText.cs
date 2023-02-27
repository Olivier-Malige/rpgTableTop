using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{

    // get input field
    public TMP_InputField inputField;
    public TextMeshProUGUI playerText;
    public void Show()
    {
        playerText.text = inputField.text;
    }
    public void Clear()
    {
        playerText.text = "";
    }

}
