
using UnityEngine;


[CreateAssetMenu(fileName = "New Adventure", menuName = "adventure")]
public class AdventureSO : ScriptableObject
{

    [SerializeField] private string adventureName;
    [SerializeField] private string description;
    [SerializeField] private GameObject mapPrefab;
    [SerializeField] private EnemySO[] enemies;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private Sprite[] images;
    [SerializeField] private Sprite worldMap;
    [SerializeField] private Sprite townMap;

    public string AdventureName { get => adventureName; }
    public string Description { get => description; }
    public GameObject MapPrefab { get => mapPrefab; }
    public EnemySO[] Enemies { get => enemies; }
    public AudioClip[] Sounds { get => sounds; }
    public Sprite[] Images { get => images; }
    public Sprite WorldMap { get => worldMap; }
    public Sprite TownMap { get => townMap; }

}
