using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AdventureManager : MonoBehaviour
{
    private AdventureSO adventure;
    [SerializeField] private GameObject imageGameObject;
    [SerializeField] private TMP_Dropdown imagesDropdown;
    [SerializeField] private TMP_Dropdown musicDropdown;
    [SerializeField] private Button adventuresButton;
    [SerializeField] private PlayMusic playMusic;
    private EnemiesController enemiesController;

    private GameObject adventureMap;


    private class Music
    {
        public string Name { get; set; }
        public AudioClip Clip { get; set; }
    }

    private class Image
    {
        public string Name { get; set; }
        public Sprite Sprite { get; set; }
    }



    private void InitializeEnemies()
    {
        enemiesController = FindObjectOfType<EnemiesController>();
        enemiesController.SetEnemies(adventure.Enemies);
    }

    private void InitializeAdventureMap()
    {
        imageGameObject.SetActive(false);
        adventureMap = Instantiate(adventure.MapPrefab, gameObject.transform);
    }

    private void InitializeImagesDropdown()
    {
        imagesDropdown.ClearOptions();
        List<Image> images = CreateImageList();
        AddImagesToDropdown(images);
        imagesDropdown.value = 0;
        imagesDropdown.RefreshShownValue();
    }

    private void InitializeMusicDropdown()
    {
        musicDropdown.ClearOptions();
        List<AudioClip> music = CreateMusicList();
        AddMusicToDropdown(music);
        musicDropdown.value = 0;
        musicDropdown.RefreshShownValue();

    }

    private List<AudioClip> CreateMusicList()
    {
        List<AudioClip> music = new List<AudioClip>();
        music.Add(null);
        foreach (var item in adventure.Sounds)
        {
            music.Add(item);
        }

        return music;
    }

    private List<Image> CreateImageList()
    {
        List<Image> images = new List<Image>();
        images.Add(null);
        images.Add(new Image { Name = "world map", Sprite = adventure.WorldMap });
        images.Add(new Image { Name = "town map", Sprite = adventure.TownMap });

        foreach (var item in adventure.Images)
        {
            images.Add(new Image { Name = item.name, Sprite = item });
        }

        return images;
    }

    private void AddImagesToDropdown(List<Image> images)
    {
        foreach (var image in images)
        {
            string name = (image != null) ? image.Name : "Level Map";
            imagesDropdown.options.Add(new TMP_Dropdown.OptionData(name));
        }
    }

    private void OnImagesDropdownValueChanged(int value)
    {
        var selectedImage = GetSelectedImage();
        if (selectedImage != null)
        {
            adventureMap.SetActive(false);
            imageGameObject.SetActive(true);
            imageGameObject.GetComponent<SpriteRenderer>().sprite = selectedImage.Sprite;
        }
        else
        {
            imageGameObject.SetActive(false);
            adventureMap.SetActive(true);
        }
    }

    private void OnMusicDropdownValueChanged(int value)
    {
        var selectedMusic = GetSelectedMusic();
        if (selectedMusic != null)
        {
            playMusic.Play(selectedMusic, 1f);
        }
        else
        {
            playMusic.Stop(1f);
        }

    }

    private Image GetSelectedImage()
    {
        List<Image> images = CreateImageList();
        int index = imagesDropdown.value;
        return images[index];
    }

    private AudioClip GetSelectedMusic()
    {
        List<AudioClip> music = CreateMusicList();
        int index = musicDropdown.value;
        return music[index];
    }

    private void AddMusicToDropdown(List<AudioClip> music)
    {
        foreach (var item in music)
        {
            string name = (item != null) ? item.name : "None";
            musicDropdown.options.Add(new TMP_Dropdown.OptionData(name));
        }
    }


    public void SetAdventure(AdventureSO adventure)
    {
        this.adventure = adventure;
        InitializeAdventureMap();
        InitializeImagesDropdown();
        InitializeMusicDropdown();
        InitializeEnemies();
        imagesDropdown.onValueChanged.AddListener(OnImagesDropdownValueChanged);
        musicDropdown.onValueChanged.AddListener(OnMusicDropdownValueChanged);
    }

    public GameObject GetAdventureMap()
    {
        return adventureMap;
    }

    public void ClearAdventure()
    {
        Destroy(adventureMap);
        imageGameObject.SetActive(false);
        this.adventure = null;
    }
}
