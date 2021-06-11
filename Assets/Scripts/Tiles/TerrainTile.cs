using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewTerrainTile", menuName = "Tiles/Terrain")]
public class TerrainTile : RuleTile
{
    public TerrainData[] flags;
}
 