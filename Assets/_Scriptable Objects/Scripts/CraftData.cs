using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CraftType
{
    Structure,
    Building,
}

public enum CraftIngrediants
{
    Rock,
    Wood
}

[CreateAssetMenu(fileName = "Craft", menuName = "New Craft")]
public class CraftData : ScriptableObject

{
    [Header("Info")]
    public string craftName;
    public string description;
    public string ingrediants;
    public CraftType type;
    public Sprite icon;
}
