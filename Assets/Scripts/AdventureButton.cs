
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureButton : MonoBehaviour
{
    Sprite image;

    [SerializeField]
    TextMeshProUGUI nameText;

    void Start()
    {
        image = GetComponent<Image>().sprite;
    }

    public void SetImage(Sprite image)
    {
        this.image = image;
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }

}
