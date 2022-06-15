using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [HideInInspector] public int gridFactor = 5;
    public static int staticGridFactor;
    public float tileSize = 1.1f;
    

    void Start()
    {
        gridFactor = staticGridFactor;
        GenerateGrid();
        AdaptCamera();
    }

    void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Tile"));
        for (var r = 0; r < gridFactor; r++)
        {
            for (var c = 0; c < gridFactor; c++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);
                tile.name = $"{c}, {r}";

                float posX = c * tileSize;
                float posY = r * tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(referenceTile);
    }

    void AdaptCamera()
    {
        // Camera.main.orthographicSize = (gridFactor + 2f) / 2;
        float camPosition = (gridFactor / 2f * tileSize) - tileSize / 2;
        Camera.main.transform.position = new Vector3(camPosition, camPosition, -10f);
        
        Camera.main.orthographicSize = camPosition + (tileSize * 0.6f);
    }

}
