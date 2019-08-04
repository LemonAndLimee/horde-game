using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingLogic : MonoBehaviour
{
    public bool isPlacing;

    public GameObject wall;
    public GameObject wallFaded;
    public GameObject wallRed;

    public GameObject gold;
    public GameObject goldFaded;
    public GameObject goldRed;

    public GameObject mine;
    public GameObject mineFaded;
    public GameObject mineRed;

    public GameObject map;

    public GameObject currentObject;
    public GameObject previousObject;

    public Vector3 pos;
    public Vector3 previousPos;

    public GameObject tile;
    public GameObject tileFaded;
    public GameObject tileRed;
    public bool canPlace;
    public bool isBig;
    public string type;
    public bool isGold;

    public ScoreLogic scoreScript;

    public int requiredStone;
    public int requiredWood;
    public int requiredGold;

    public ObjectLimits limitScript;

    public List<Vector3> occupied = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlacing == true)
        {
            if (isGold == true || limitScript.gold == limitScript.goldLimit)
            {
                if (requiredStone <= scoreScript.stone && requiredWood <= scoreScript.wood && requiredGold <= scoreScript.gold)
                {
                    if (previousPos != new Vector3(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y), 0f))
                    {
                        canPlace = true;

                        currentObject = Instantiate(tileFaded, map.transform);

                        currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        pos = currentObject.transform.position;
                        currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
                        pos = currentObject.transform.position;


                        if (type == "Wall")
                        {
                            if (limitScript.walls >= limitScript.wallLimit)
                            {
                                canPlace = false;
                            }
                        }
                        else if (type == "Gold")
                        {
                            if (limitScript.gold >= limitScript.goldLimit)
                            {
                                canPlace = false;
                            }
                        }
                        else if (type == "Mine")
                        {
                            if (limitScript.mines >= limitScript.mineLimit)
                            {
                                canPlace = false;
                            }
                        }


                        if (isBig == true)
                        {
                            if (occupied.Contains(currentObject.transform.position) || occupied.Contains(new Vector3(currentObject.transform.position.x, currentObject.transform.position.y + 1f, currentObject.transform.position.z)) || occupied.Contains(new Vector3(currentObject.transform.position.x + 1f, currentObject.transform.position.y + 1f, currentObject.transform.position.z)) || occupied.Contains(new Vector3(currentObject.transform.position.x + 1f, currentObject.transform.position.y, currentObject.transform.position.z)))
                            {
                                canPlace = false;
                            }

                        }
                        else
                        {
                            if (occupied.Contains(currentObject.transform.position))
                            {
                                canPlace = false;
                            }
                        }

                        if (canPlace == false)
                        {
                            Destroy(currentObject);
                            currentObject = Instantiate(tileRed, map.transform);

                            currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            pos = currentObject.transform.position;
                            currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
                        }

                        Destroy(previousObject);
                        previousObject = currentObject;
                        previousPos = previousObject.transform.position;

                    }
                    if (Input.GetMouseButtonDown(0))
                    {

                        if (canPlace == true)
                        {
                            Destroy(currentObject);
                            currentObject = Instantiate(tile, map.transform);

                            currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            pos = currentObject.transform.position;
                            currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);

                            occupied.Add(currentObject.transform.position);

                            if (isBig == true)
                            {
                                occupied.Add(new Vector3(currentObject.transform.position.x, currentObject.transform.position.y + 1f, currentObject.transform.position.z));
                                occupied.Add(new Vector3(currentObject.transform.position.x + 1f, currentObject.transform.position.y, currentObject.transform.position.z));
                                occupied.Add(new Vector3(currentObject.transform.position.x + 1f, currentObject.transform.position.y + 1f, currentObject.transform.position.z));
                            }

                            currentObject = null;

                            scoreScript.Add(0, -requiredWood);
                            scoreScript.Add(1, -requiredStone);
                            scoreScript.Add(2, -requiredGold);

                            if (type == "Wall")
                            {
                                limitScript.walls += 1;
                            }
                            else if (type == "Gold")
                            {
                                limitScript.gold += 1;
                            }
                            else if (type == "Mine")
                            {
                                limitScript.mines += 1;
                            }

                            previousPos = new Vector3(1000f, 1000f, 0f);
                            isPlacing = false;
                            isPlacing = true;

                        }
                    }
                    else if (Input.GetMouseButtonDown(1))
                    {
                        Destroy(currentObject);
                        previousPos = new Vector3(1000f, 1000f, 0f);
                        isPlacing = false;
                    }
                }
                else
                {
                    Destroy(currentObject);
                    previousPos = new Vector3(1000f, 1000f, 0f);
                    isPlacing = false;
                }
            }

            
        }
    }

    public void TogglePlacing(GameObject t, GameObject faded, GameObject red, bool big, int wood, int stone, int gold, string info)
    {
        if (isPlacing == false)
        {
            isPlacing = true;
            tile = t;
            tileFaded = faded;
            tileRed = red;
            isBig = big;

            requiredWood = wood;
            requiredStone = stone;
            requiredGold = gold;

            type = info;
        }
        else
        {
            isPlacing = false;
            Destroy(currentObject);
        }
    }

    public void PlaceWall()
    {
        TogglePlacing(wall, wallFaded, wallRed, false, 5, 0, 0, "Wall");
    }

    public void PlaceGold()
    {
        TogglePlacing(gold, goldFaded, goldRed, true, 0, 0, 0, "Gold");
        isGold = true;
    }

    public void PlaceMine()
    {
        TogglePlacing(mine, mineFaded, mineRed, true, 5, 5, 0, "Mine");
    }


}
