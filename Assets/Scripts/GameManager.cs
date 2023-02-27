using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas gameMasterCanvas;
    [SerializeField] Canvas PlayersCanvas;

    [SerializeField] GameObject fogEditingButton;
    [SerializeField] GameObject enemiesEditingButton;
    [SerializeField] GameObject marksEditingButton;

    FogController fogController;
    EnemiesController enemiesController;
    MarksController marksController;

    Image fogEditingButtonImage;
    Image enemiesEditingButtonImage;
    Image marksEditingButtonImage;

    void Start()
    {
        enemiesController = FindObjectOfType<EnemiesController>();
        marksController = FindObjectOfType<MarksController>();
        fogEditingButtonImage = fogEditingButton.GetComponent<Image>();
        enemiesEditingButtonImage = enemiesEditingButton.GetComponent<Image>();
        marksEditingButtonImage = marksEditingButton.GetComponent<Image>();

    }


    public void SetFogEditing()
    {

        FindObjectOfType<FogController>().isEditing = true;
        enemiesController.isEditing = false;
        marksController.isEditing = false;
        fogEditingButtonImage.color = Color.green;
        enemiesEditingButtonImage.color = Color.white;
        marksEditingButtonImage.color = Color.white;

    }
    public void SetEnemiesEditing()
    {
        FindObjectOfType<FogController>().isEditing = false;
        enemiesController.isEditing = true;
        marksController.isEditing = false;
        enemiesEditingButtonImage.color = Color.green;
        fogEditingButtonImage.color = Color.white;
        marksEditingButtonImage.color = Color.white;
    }

    public void SetMarksEditing()
    {
        FindObjectOfType<FogController>().isEditing = false;
        enemiesController.isEditing = false;
        marksController.isEditing = true;
        marksEditingButtonImage.color = Color.green;
        enemiesEditingButtonImage.color = Color.white;
        fogEditingButtonImage.color = Color.white;
    }



}
