using System.Collections;
using System.Collections.Generic;
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

    public bool isEditing = false;

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
            fogButtonGroup.SetActive(false);
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


    public void EditFog()
    {
        isEditing = true;
    }

    // stop editing fog
    public void StopEditFog()
    {
        isEditing = false;
    }

    public void UpdateFrog()
    {
        print("update fog");
        // replace player fog with fog
        playerTileMap.ClearAllTiles();
        playerTileMap.SetTilesBlock(gameMasterTileMap.cellBounds, gameMasterTileMap.GetTilesBlock(gameMasterTileMap.cellBounds));
    }


}
