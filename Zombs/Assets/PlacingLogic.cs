using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingLogic : MonoBehaviour
{
    public bool isPlacing;

    public GameObject wall;
    public GameObject wallFaded;

    public GameObject map;

    public GameObject currentObject;
    public GameObject previousObject;

    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlacing == true)
        {
            if (previousObject.transform.position != new Vector3(Mathf.Round(Input.mousePosition.x), Mathf.Round(Input.mousePosition.y), 0f))
            {

            }
            currentObject = Instantiate(wallFaded, map.transform);
            currentObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos = currentObject.transform.position;
            currentObject.transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0f);
        }

        if (Input.GetKeyDown("e"))
        {
            TogglePlacing();
        }
    }

    public void TogglePlacing()
    {
        if (isPlacing == false)
        {
            isPlacing = true;
        }
        else
        {
            isPlacing = false;
        }
    }


}
