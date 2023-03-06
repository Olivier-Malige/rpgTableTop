
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class FogController : MonoBehaviour
{

    [SerializeField] Tilemap gameMasterTileMap;
    [SerializeField] Tilemap playerTileMap;
    [SerializeField] TileBase fogTile;

    GameObject fogButtonGroup;
    Button applyFogButton;


    void Start()
    {
        gameMasterTileMap.gameObject.SetActive(true);
        playerTileMap.gameObject.SetActive(true);
        fogButtonGroup = GameObject.Find("FogButtonGroup");

        applyFogButton = GameObject.Find("ApplyFogButton").GetComponent<Button>();
        applyFogButton.onClick.AddListener(UpdateFrog);
    }

    void Update()
    {
        bool isEditing = GameManager.instance.GetEditingMode() == GameManager.EditingMode.Fog;
        if (isEditing)
        {
            fogButtonGroup.SetActive(true);
            if ((Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space)) && !EventSystem.current.IsPointerOverGameObject())
            {
                CreateTile();
            }

            if ((Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Delete)) && !EventSystem.current.IsPointerOverGameObject())
            {
                RemoveTile();
            }

        }
        else
        {
            if (fogButtonGroup)
            {
                fogButtonGroup.SetActive(false);
            }

        }

    }

    void CreateTile()
    {

        // get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // set tile from at mouse position
        gameMasterTileMap.SetTile(gameMasterTileMap.WorldToCell(mousePosition), fogTile);
    }

    void RemoveTile()
    {
        // get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // remove tile at mouse position
        gameMasterTileMap.SetTile(gameMasterTileMap.WorldToCell(mousePosition), null);
    }


    public void UpdateFrog()
    {
        playerTileMap.ClearAllTiles();
        playerTileMap.SetTilesBlock(gameMasterTileMap.cellBounds, gameMasterTileMap.GetTilesBlock(gameMasterTileMap.cellBounds));
    }

    public void ClearFog()
    {
        gameMasterTileMap.ClearAllTiles();
        playerTileMap.ClearAllTiles();
    }


}
