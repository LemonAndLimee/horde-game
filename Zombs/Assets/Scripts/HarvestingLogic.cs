using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingLogic : MonoBehaviour
{
	public PlacingLogic placementScript;
    public ScoreLogic scoreScript;

    public bool isHarvesting;

    public bool canTree;
    public bool canStone;

    public float treeTimer;
    public float treeTime;

    public float stoneTimer;
    public float stoneTime;

    public GameObject currentTree;
    public GameObject currentStone;

    public TreeMovement treeScript;
    public StoneMovement stoneScript;
    

    // Start is called before the first frame update
    void Start()
    {
        treeTime = 0.5f;
        stoneTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Harvest();
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            isHarvesting = false;
            if (currentTree != null)
            {
                treeScript.isHarvested = false;
            }
            if (currentStone != null)
            {
                stoneScript.isHarvested = false;
            }

        }
    }

    public void Harvest()
    {
        if (placementScript.isPlacing == false)
        {
            if (canTree == true)
            {
                isHarvesting = true;
                treeScript.isHarvested = true;

                treeTimer += Time.deltaTime;
                if (treeTimer >= treeTime) 
                {
                    scoreScript.Add(0, 1);
                    treeTimer = 0f;
                }
            }
            else
            {
                isHarvesting = false;
                if (currentTree != null)
                {
                    treeScript.isHarvested = false;
                }
            }
            if (canStone == true)
            {
                isHarvesting = true;
                stoneScript.isHarvested = true;

                stoneTimer += Time.deltaTime;
                if (stoneTimer >= stoneTime)
                {
                    scoreScript.Add(1, 1);
                    stoneTimer = 0f;
                }
            }
            else
            {
                isHarvesting = false;
                if (currentStone != null)
                {
                    stoneScript.isHarvested = false;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Tree")
        {
            canTree = true;
            currentTree = collider.gameObject;
            treeScript = currentTree.GetComponent<TreeMovement>();
        }
        if (collider.tag == "Stone")
        {
            canStone = true;
            currentStone = collider.gameObject;
            stoneScript = currentStone.GetComponent<StoneMovement>();
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Tree")
        {
            canTree = false;
        }
        if (collider.tag == "Stone")
        {
            canStone = false;
        }
    }

}
