using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour
{

    public GameObject enemyPrefab;
    Vector3 mousePosition;
    private bool inAdding;

    void Update()
    {
        // get mouse position
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (inAdding)
        {

            if (Input.GetMouseButtonDown(0))
            {
                var enemy = Instantiate(enemyPrefab, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);

            }

            // right click pyhsics2d raycast
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    Destroy(hit.collider.gameObject);
                }
            }

            // remove on escape
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inAdding = false;

            }
        }

    }


}
