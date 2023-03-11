using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Canvas gameMasterCanvas;
    [SerializeField] Canvas playersCanvas;

    [SerializeField] GameObject adventureUI;
    [SerializeField] GameObject adventureSelectionUI;

    [SerializeField] GameObject fogEditingButton;
    [SerializeField] GameObject enemiesEditingButton;
    [SerializeField] GameObject marksEditingButton;

    [SerializeField] AdventureSO[] adventures;
    [SerializeField] AdventureButton adventureButtonPrefab;
    [SerializeField] Button adventuresButton;

    FogController fogController;
    AdventureSO currentAdventure;

    [SerializeField]
    EnemiesController enemiesController;

    AdventureManager adventureManager;

    public enum EditingMode
    {
        None,
        Fog,
        Enemies,
        Marks
    }

    private EditingMode editingMode = EditingMode.None;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        adventureManager = FindObjectOfType<AdventureManager>();
        adventureUI.SetActive(false);
        adventureSelectionUI.SetActive(true);

        enemiesEditingButton.GetComponent<Button>().onClick.AddListener(() => SetEditingMode(EditingMode.Enemies));
        fogEditingButton.GetComponent<Button>().onClick.AddListener(() => SetEditingMode(EditingMode.Fog));
        marksEditingButton.GetComponent<Button>().onClick.AddListener(() => SetEditingMode(EditingMode.Marks));
        adventuresButton.onClick.AddListener(ClearAdventure);


        foreach (AdventureSO adventure in adventures)
        {
            AdventureButton adventureButton = Instantiate(adventureButtonPrefab, adventureSelectionUI.transform);
            adventureButton.SetImage(adventure.AdventureImage);
            adventureButton.SetName(adventure.name);
            adventureButton.GetComponent<Button>().onClick.AddListener(() => SetAdventure(adventure));
        }

        SetEditingMode(editingMode);
    }

    private void ClearAdventure()
    {
        SetEditingMode(EditingMode.None);
        adventureSelectionUI.SetActive(true);
        adventureUI.SetActive(false);
        currentAdventure = null;
        adventureManager.ClearAdventure();
        enemiesController.ClearEnemies();

    }

    public void SetEditingMode(EditingMode mode)
    {
        editingMode = mode;
        SetEditingButtonColor(fogEditingButton, editingMode == EditingMode.Fog);
        SetEditingButtonColor(enemiesEditingButton, editingMode == EditingMode.Enemies);
        SetEditingButtonColor(marksEditingButton, editingMode == EditingMode.Marks);

    }

    private void SetEditingButtonColor(GameObject button, bool isEditing)
    {
        button.GetComponent<Image>().color = isEditing ? Color.green : Color.white;
    }

    public void SetAdventure(AdventureSO adventure)
    {
        currentAdventure = adventure;
        adventureManager.SetAdventure(adventure);
        adventureSelectionUI.SetActive(false);
        adventureUI.SetActive(true);
        SetEditingMode(EditingMode.None);
    }

    public EditingMode GetEditingMode()
    {
        return editingMode;
    }

}