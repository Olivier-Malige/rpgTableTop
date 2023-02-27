
using UnityEngine;

public class MapsManager : MonoBehaviour
{
    [SerializeField] GameObject worldMap;
    [SerializeField] GameObject townMap;
    [SerializeField] GameObject levelMap;

    void Start()
    {
        worldMap.SetActive(false);
        townMap.SetActive(false);
        levelMap.SetActive(false);
    }

    public void ShowWorldMap()
    {
        worldMap.SetActive(true);
        townMap.SetActive(false);
        levelMap.SetActive(false);
    }

    public void ShowTownMap()
    {
        worldMap.SetActive(false);
        townMap.SetActive(true);
        levelMap.SetActive(false);
    }

    public void ShowLevelMap()
    {
        townMap.SetActive(false);
        levelMap.SetActive(true);
        worldMap.SetActive(false);
    }

    public void ShowMap(int mapIndex)
    {
        switch (mapIndex)
        {
            case 0:
                ShowLevelMap();
                break;
            case 1:
                ShowTownMap();
                break;
            case 2:
                ShowWorldMap();
                break;
        }
    }


}
