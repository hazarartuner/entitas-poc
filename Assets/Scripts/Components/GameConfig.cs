using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, CreateAssetMenu(menuName = "Config/Game Config")]
public class GameConfig : ScriptableObject
{
    public GameObject[] Candies;

    public int colCount = 12;

    public int rowCount = 8;

    public int itemWidth = 10;

    public int itemHeight = 10;
}