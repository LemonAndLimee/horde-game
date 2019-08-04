using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLimits : MonoBehaviour
{

    public int wallLimit;
    public int walls;

    public int goldLimit;
    public int gold;

    // Start is called before the first frame update
    void Start()
    {
        wallLimit = 250;
        goldLimit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
