using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewTerrainTile", menuName = "Tiles/Terrain")]
public class TerrainTile : TileBase
{
    public TerrainData[] flags;
}
 