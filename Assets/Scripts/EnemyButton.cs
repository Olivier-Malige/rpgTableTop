
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Button button;
    [SerializeField] Button buttonStats;

    private EnemyStats EnemyStats;

    string enemyName;

    void Start()
    {
        EnemyStats = FindObjectOfType<EnemyStats>();
    }

    public void SetEnemy(EnemySO enemySO)
    {
        image.sprite = enemySO.image;
        button.onClick.AddListener(() => FindObjectOfType<EnemiesController>().SetSelectedEnemy(enemySO));
        buttonStats.onClick.AddListener(() => EnemyStats.ShowEnemyStats(enemySO));
    }
    public string GetEnemyName()
    {
        return enemyName;
    }


    public void SetSelected(bool selected)
    {
        if (selected)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.white;
        }
    }

}
