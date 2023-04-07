using UnityEngine;

public class ScreenSize : MonoBehaviour
{

    [SerializeField] RectTransform image;
    void Start()
    {

        if (Application.isPlaying)
        {

            float width = Display.displays[1].renderingWidth;
            float height = Display.displays[1].renderingHeight;

            float ratio = width / height;
            // set image with the radio
            image.sizeDelta = new Vector2(image.sizeDelta.y * ratio, image.sizeDelta.y);



        }



    }


}
