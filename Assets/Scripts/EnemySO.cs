
using System;
using UnityEngine;

[System.Serializable]
public class Action
{
    public string name;
    public string content;
}

[System.Serializable]
public enum Size { Tiny, Small, Medium, Large, Huge, Gargantuan }

[CreateAssetMenu(fileName = "New Enemy", menuName = "enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] string alignment;
    [SerializeField] Size size;
    [SerializeField] int armorClass;
    [SerializeField] string speed;
    [SerializeField] string strength;
    [SerializeField] string dexterity;
    [SerializeField] string constitution;
    [SerializeField] string intelligence;
    [SerializeField] string wisdom;
    [SerializeField] string charisma;
    [SerializeField] string power;
    [SerializeField] string description;
    [SerializeField] string languages;
    [SerializeField] string skills;
    [SerializeField] string senses;

    [SerializeField] Action[] capacity;
    [SerializeField] Action[] actions;


    public Sprite image;
    public int health;



    public string getStats()
    {

        return "CA: " + armorClass + "\n" +
               "PV: " + health + "\n" +
               "Vitesse: " + speed + "\n" +
               "alignement: " + alignment + "\n" +
               "FOR: " + strength +
               " DEX: " + dexterity +
               " CON: " + constitution +
               " INT: " + intelligence +
               " SAG: " + wisdom +
               " CHA: " + charisma + "\n" +
               "Puissance: " + power + "\n" +
               "Langues: " + languages + "\n" +
               "Compétences: " + skills + "\n" +
               "Sens: " + senses + "\n";

    }

    public string getDescription()
    {
        return description;
    }

    public string getAlignment()
    {
        return alignment;
    }

    public Size getSize()
    {
        return size;
    }


    public string getActions()
    {
        string actions = "";
        foreach (Action action in capacity)
        {
            actions += action.name + ": " + action.content + "\n\n";
        }
        return actions;
    }

    public string getCapacity()
    {
        string capacity = "";
        foreach (Action action in actions)
        {
            capacity += action.name + ": " + action.content + "\n\n";
        }
        return capacity;
    }



}
