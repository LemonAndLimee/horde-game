using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGeneration : MonoBehaviour
{
    public GameObject tree;
    public GameObject stone;

    public GameObject currentObject;

    public PlacingLogic placementScript;

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            int type = Random.Range(0, 2);
            if (type == 0)
            {
                currentObject = Instantiate(tree);
                Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                currentObject.transform.position = position;

                placementScript.occupied.Add(position);

                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 2f, position.y, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 2f, position.y, position.z));

                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y + 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 2f, position.y + 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x, position.y + 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y + 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 2f, position.y + 1f, position.z));

                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y + 2f, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y + 2f, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 2f, position.y + 2f, position.z));

                placementScript.occupied.Add(new Vector3(position.x + 2f, position.y - 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y - 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x, position.y - 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y - 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 2f, position.y - 1f, position.z));

                placementScript.occupied.Add(new Vector3(position.x, position.y - 2f, position.z));
                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y - 2f, position.z));
            }
            else
            {
                currentObject = Instantiate(stone);
                Vector3 position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
                currentObject.transform.position = position;

                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y + 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x, position.y + 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y + 1f, position.z));

                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y, position.z));
                placementScript.occupied.Add(new Vector3(position.x, position.y, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y, position.z));

                placementScript.occupied.Add(new Vector3(position.x + 1f, position.y - 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x, position.y - 1f, position.z));
                placementScript.occupied.Add(new Vector3(position.x - 1f, position.y - 1f, position.z));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
