using UnityEngine;
using UnityEngine.EventSystems;

public class MarksController : MonoBehaviour
{

    [SerializeField] GameObject markPrefab;

    private void Update()
    {

        if (GameManager.instance.GetEditingMode() == GameManager.EditingMode.Marks)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var mark = Instantiate(markPrefab, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity, transform);
            }
        }
    }

}
