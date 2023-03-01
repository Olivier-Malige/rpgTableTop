using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemiesController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool isEditing;
    public GameObject characterToMove;
    public EnemySO[] enemies;
    public EnemySO selectedEnemy;
    public List<GameObject> enemiesButtons = new List<GameObject>();

    [SerializeField] private GameObject enemyButtonPrefab;
    [SerializeField] private GameObject enemiesButtonGroup;

    private Vector3 mousePosition;

    private void Start()
    {
        enemiesButtonGroup.SetActive(false);
    }

    private void Update()
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
                    GameObject enemy = Instantiate(enemyPrefab, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity, transform);
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
            var EnemyButton = enemyButton.GetComponent<EnemyButton>();
            print(EnemyButton.GetEnemyName());
            print(enemy.name);
            EnemyButton.SetSelected(EnemyButton.GetEnemyName() == enemy.name);
        }
    }
}