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

    public GameObject map;

    public GameObject currentObject;
    public GameObject previousObject;

    public Vector3 pos;
    public Vector3 previousPos;

    public GameObject tile;
    public GameObject tileFaded;
    public GameObject tileRed;
    public FadedLogic fadedScript;
    public bool canPlace;
    public bool isBig;

    public ScoreLogic scoreScript;

    public int requiredStone;
    public int requiredWood;
    public int requiredGold;

    public List<Vector3> occupied = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        canPlace = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlacing == true)
        {
            if (requiredStone <= scoreScript.stone && requiredWood <= scoreScript.wood && requiredGold <= scoreScript.gold)
            {
                if (previousPos != new Vector3(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y), 0f))
                {
                    currentObject = Instantiate(tileFaded, map.transform);
                    fadedScript = currentObject.GetComponent<FadedLogic>();

                    currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos = currentObject.transform.position;
                    currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
                    pos = currentObject.transform.position;

                    if (isBig == true)
                    {
                        if (occupied.Contains(currentObject.transform.position) || occupied.Contains(new Vector3(currentObject.transform.position.x, currentObject.transform.position.y + 1f, currentObject.transform.position.z)) || occupied.Contains(new Vector3(currentObject.transform.position.x + 1f, currentObject.transform.position.y + 1f, currentObject.transform.position.z)) || occupied.Contains(new Vector3(currentObject.transform.position.x + 1f, currentObject.transform.position.y, currentObject.transform.position.z)))
                        {
                            canPlace = false;
                            Destroy(currentObject);
                            currentObject = Instantiate(tileRed, map.transform);

                            currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            pos = currentObject.transform.position;
                            currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
                        }
                        else
                        {
                            canPlace = true;
                        }

                    }
                    else
                    {
                        if (occupied.Contains(currentObject.transform.position))
                        {
                            canPlace = false;
                            Destroy(currentObject);
                            currentObject = Instantiate(tileRed, map.transform);

                            currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            pos = currentObject.transform.position;
                            currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
                        }
                        else
                        {
                            canPlace = true;
                        }
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

                        previousPos = new Vector3(1000f, 1000f, 0f);
                        isPlacing = false;
                        isPlacing = true;

                    }
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

    public void TogglePlacing(GameObject t, GameObject faded, GameObject red, bool big, int wood, int stone, int gold)
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
        }
        else
        {
            isPlacing = false;
            Destroy(currentObject);
        }
    }

    public void PlaceWall() {

        TogglePlacing(wall, wallFaded, wallRed, false, 5, 0, 0);

    }

    public void PlaceGold() {
        TogglePlacing(gold, goldFaded, goldRed, true, 0, 0, 0);
    }


}
