using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Button close;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        close.onClick.AddListener(CloseEnemyStats);
        panel.SetActive(false);
    }

    public void ShowEnemyStats(EnemySO enemySO)
    {
        panel.SetActive(true);
        text.text = enemySO.name + "\n\n"
       + enemySO.getStats() + "\n\n"
       + enemySO.getCapacity() + "\n\n"
       + enemySO.getActions() + "\n\n"
       + enemySO.getDescription();
    }

    void CloseEnemyStats()
    {
        panel.SetActive(false);
    }

}
