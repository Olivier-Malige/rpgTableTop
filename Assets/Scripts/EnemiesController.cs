
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EnemiesController : MonoBehaviour
{
    public GameObject enemyPrefab;

    private EnemySO[] enemies;
    [SerializeField] GameObject enemyButtonPrefab;

    Vector3 mousePosition;
    public bool isEditing;

    GameObject characterToMove;

    [SerializeField] GameObject enemiesButtonGroup;

    EnemySO selectedEnemy;
    List<GameObject> enemiesButtons = new List<GameObject>();


    private void Start()
    {
        enemiesButtonGroup.SetActive(false);

    }


    void Update()
    {
        if (isEditing && !characterToMove)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            enemiesButtonGroup.SetActive(true);
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);
                if (hit.collider.CompareTag("Map"))
                {
                    var enemy = Instantiate(enemyPrefab, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity, transform);
                    enemy.GetComponent<Enemy>().SetEnemy(selectedEnemy);
                }
                else if (hit.collider.CompareTag("Character"))
                {
                    characterToMove = hit.collider.gameObject;
                }
            }
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Delete))
            {
                int layerMask = LayerMask.GetMask("enemies");
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
                if (hit && hit.collider.CompareTag("Character") && !EventSystem.current.IsPointerOverGameObject())
                {
                    Destroy(hit.collider.gameObject);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int layerMask = LayerMask.GetMask("enemies");
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
                if (hit && hit.collider.CompareTag("Character") && !EventSystem.current.IsPointerOverGameObject())
                {
                    hit.collider.gameObject.GetComponent<Enemy>().removeHealth(1);
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                int layerMask = LayerMask.GetMask("enemies");
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, layerMask);
                if (hit && hit.collider.CompareTag("Character") && !EventSystem.current.IsPointerOverGameObject())
                {
                    hit.collider.gameObject.GetComponent<Enemy>().addHealth(1);
                }
            }


        }
        else if (isEditing && characterToMove)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            characterToMove.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
            if (Input.GetMouseButtonDown(0))
            {
                characterToMove = null;
            }
        }
        else
        {
            enemiesButtonGroup.SetActive(false);
        }

    }

    public void SetEnemies(EnemySO[] enemies)
    {

        this.enemies = enemies;
        foreach (EnemySO enemy in enemies)
        {
            GameObject enemyButton = Instantiate(enemyButtonPrefab, enemiesButtonGroup.transform);
            enemyButton.GetComponent<EnemyButton>().SetEnemy(enemy);
            enemiesButtons.Add(enemyButton);
        }
        SetSelectedEnemy(enemies[0]);

    }

    public void SetSelectedEnemy(EnemySO enemy)
    {
        selectedEnemy = enemy;
        foreach (GameObject enemyButton in enemiesButtons)
        {
            if (enemyButton.GetComponent<EnemyButton>().GetEnemyName() == enemy.name)
            {
                enemyButton.GetComponent<Image>().color = Color.green;
            }
            else
            {
                // enemyButton.GetComponent<Image>().color = Color.white;
            }
        }
    }
}
