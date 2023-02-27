using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MarksController : MonoBehaviour
{

    [SerializeField] GameObject markPrefab;
    public bool isEditing;

    private void Update()
    {
        if (isEditing)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var mark = Instantiate(markPrefab, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity, transform);
            }
        }
    }

}
