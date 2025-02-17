using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapObjectSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject[] objectPrefab;
    public int numberOfObjects = 10;
    public int maxAttempts = 100;

    private void Start()
    {
        SpawnFlowers();
    }

    void SpawnFlowers()
    {
        for(int i = 0; i<numberOfObjects; i++)
        {
            Vector3 randomPosition;
            bool found = TryGetRandomPosition(out randomPosition);
            if(found)
            {
                GameObject randomObject = objectPrefab[Random.Range(0, objectPrefab.Length)];
                GameObject objectInstance =  Instantiate(randomObject, randomPosition, Quaternion.identity);
                objectInstance.name = randomObject.name;

                //오브젝트의 SpriteRenderer설정
                SpriteRenderer sr = objectInstance.GetComponent<SpriteRenderer>();
                if(sr != null)
                {
                    sr.sortingLayerName = "Tile Objects";
                    sr.sortingOrder = 1;
                }

            }
            else
            {
                Debug.Log("failed");
            }
        }
    }
    


    bool TryGetRandomPosition(out Vector3 position)
    {
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int min = bounds.min;
        Vector3Int max = bounds.max;

        for(int attempt = 0; attempt < maxAttempts; attempt++)
        {
            Vector3Int randomCell = new Vector3Int(
                Random.Range(min.x, max.x),
                Random.Range(min.y, max.y),
                0
                );

            if (tilemap.HasTile(randomCell))
            {
                position = tilemap.CellToWorld(randomCell) + tilemap.tileAnchor;
                return true;
            }
        }

        position = Vector3.zero;
        return false;
    }


}
