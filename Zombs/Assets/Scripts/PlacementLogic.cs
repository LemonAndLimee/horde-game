using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlacementLogic : MonoBehaviour
{
    public Tilemap x1map;

    public Tilemap map;

    public Tile tile;
    public Tile tileFaded;
    public Tile tileRed;

    public Tile savedTile;

    public Tile block;
    public Tile blockFaded;
    public Tile blockRed;

    public Tile gold;
    public Tile goldFaded;
    public Tile goldRed;

    public Vector3Int previous = new Vector3Int(1000, 1000, 1000);

    public bool isPlacing = false;

    public Vector3 mouseWorldPos;
    public Vector3Int coordinate;

    public ScoreLogic scoreScript;

    public int requiredStone;
    public int requiredWood;
    public int requiredGold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isPlacing == true)
        {
            if (requiredStone <= scoreScript.stone && requiredWood <= scoreScript.wood && requiredGold <= scoreScript.gold)
            {

                coordinate = map.WorldToCell(mouseWorldPos);
                if (coordinate != previous)
                {
                    if (map.GetTile(coordinate) == null)
                    {
                        map.SetTile(coordinate, tileFaded);

                        if (map.GetTile(previous) == tileRed)
                        {
                            map.SetTile(previous, savedTile);
                        }
                        else
                        {
                            map.SetTile(previous, null);
                        }

                        // save the new position for next frame
                        previous = coordinate;
                    }
                    else if (map.GetTile(coordinate) == block)
                    {
                        savedTile = block;

                        map.SetTile(coordinate, tileRed);

                        if (map.GetTile(previous) == tileRed)
                        {
                            map.SetTile(previous, savedTile);
                        }
                        else
                        {
                            map.SetTile(previous, null);
                        }

                        // save the new position for next frame
                        previous = coordinate;
                    }

                }

                if (Input.GetMouseButtonDown(0))
                {
                    map.SetTile(coordinate, tile);
                    scoreScript.Add(0, -requiredWood);
                    scoreScript.Add(1, -requiredStone);
                    scoreScript.Add(2, -requiredGold);
                    previous = new Vector3Int(1000, 1000, 1000);
                    isPlacing = false;
                    isPlacing = true;
                }
                else if (Input.GetMouseButton(1))
                {
                    coordinate = map.WorldToCell(mouseWorldPos);
                    isPlacing = false;
                    if (map.GetTile(coordinate) == tileFaded)
                    {
                        map.SetTile(coordinate, null);
                    }
                    else if (map.GetTile(coordinate) == tileRed)
                    {
                        map.SetTile(coordinate, savedTile);
                    }
                    previous = new Vector3Int(0, 0, 0);
                }
            }
            else
            {
                coordinate = map.WorldToCell(mouseWorldPos);
                isPlacing = false;
                if (map.GetTile(coordinate) == tileFaded)
                {
                    map.SetTile(coordinate, null);
                }
                else if (map.GetTile(coordinate) == tileRed)
                {
                    map.SetTile(coordinate, savedTile);
                }
                previous = new Vector3Int(0, 0, 0);
            }
            

        }

        
    }

    public void TogglePlace(Tile t, Tile faded, Tile red, Tilemap tilemap, int stone, int wood, int gold)
    {
        if (isPlacing == false)
        {
            requiredStone = stone;
            requiredWood = wood;
            requiredGold = gold;

            isPlacing = true;
            tile = t;
            tileFaded = faded;
            tileRed = red;
            map = tilemap;

        }
        else
        {
            coordinate = map.WorldToCell(mouseWorldPos);
            isPlacing = false;
            if (map.GetTile(coordinate) == tileFaded)
            {
                map.SetTile(coordinate, null);
            }
            else if (map.GetTile(coordinate) == tileRed)
            {
                map.SetTile(coordinate, savedTile);
            }
            previous = new Vector3Int(0, 0, 0);
        }
    }

    public void Wall()
    {
        TogglePlace(block, blockFaded, blockRed, x1map, 0, 5, 0);
    }
    public void Gold()
    {
        TogglePlace(gold, goldFaded, goldRed, x1map, 0, 0, 0);
    }

}
