
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemySO enemySO;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Slider healthSlider;


    void Start()
    {
        spriteRenderer.sprite = enemySO.image;
        healthSlider.maxValue = enemySO.health;
        healthSlider.value = enemySO.health;
    }

    public void addHealth(int health)
    {
        healthSlider.value += health;
        if (healthSlider.value > 0)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void removeHealth(int health)
    {

        healthSlider.value -= health;
        if (healthSlider.value <= 0)
        {

            spriteRenderer.color = Color.red;
        }
    }


    public void SetEnemy(EnemySO enemySO)
    {
        this.enemySO = enemySO;
        spriteRenderer.sprite = enemySO.image;
        // get enemy size and scale it
        float scale = 1;


        switch (enemySO.getSize())
        {
            case Size.Tiny:
                scale = 0.75f;
                break;
            case Size.Small:
                scale = 1f;
                break;
            case Size.Medium:
                scale = 1f;
                break;
            case Size.Large:
                scale = 2f;
                break;
            case Size.Huge:
                scale = 3f;
                break;
            case Size.Gargantuan:
                scale = 4f;
                break;
        }
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
