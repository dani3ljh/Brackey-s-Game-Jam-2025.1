using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] Tilemap grassTilemap, rockTilemap;
    [SerializeField] Tile grass, rock;
    [SerializeField] float rockChance;

    private void Start()
    {
        GenerateTilemap();
    }

    void GenerateTilemap()
    {
        for (int x = 0; x < width; x++)
        {
            rockChance += 0.01f;
            for (int y = 0; y < height; y++)
            {
                if (Random.Range(0, 100) > rockChance)
                {
                    grassTilemap.SetTile(new Vector3Int(x, y, 0), grass);
                }
                else
                {
                    grassTilemap.SetTile(new Vector3Int(x, y, 0), grass);
                    rockTilemap.SetTile(new Vector3Int(x, y, 0), rock);
                }
            }
        }
    }
}
