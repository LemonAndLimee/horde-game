using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    public bool isHarvested;

    public Animation move;

    // Start is called before the first frame update
    void Start()
    {
        move = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHarvested == true)
        {
            move.Play();
        }
    }
}
