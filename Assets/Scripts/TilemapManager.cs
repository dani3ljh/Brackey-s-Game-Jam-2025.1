using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Handles Making Tilemap
/// </summary>
public class TilemapManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private int width, height;
    [SerializeField] private float startRockChance;
    [SerializeField] private float deltaRockChance;
    [SerializeField] private float maxRockChance;
    private float rockChance;

    [Header("Game Objects")]
    [SerializeField] private Tilemap grassTilemap, rockTilemap;
    [SerializeField] private Tile grass, rock;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods are called.
    /// </summary>
    private void Start() {
        rockChance = startRockChance;
        GenerateTilemap();
    }

    /// <summary>
    /// Generates Tilemap filled with random rocks.
    /// </summary>
    private void GenerateTilemap() {
        for (int x = 0; x < width; x++) {
            rockChance += deltaRockChance;
            for (int y = 0; y < height; y++) {
                if (Random.Range(0, 100) > rockChance) {
                    grassTilemap.SetTile(new Vector3Int(x, y, 0), grass);
                } else {
                    grassTilemap.SetTile(new Vector3Int(x, y, 0), grass);
                    rockTilemap.SetTile(new Vector3Int(x, y, 0), rock);
                }
            }
        }
    }
}
