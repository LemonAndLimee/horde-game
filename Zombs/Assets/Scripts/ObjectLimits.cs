using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLimits : MonoBehaviour
{
    public int goldTier;

    public int wallLimit;
    public int walls;

    public int goldLimit;
    public int gold;

    public int mineLimit;
    public int mines;

    // Start is called before the first frame update
    void Start()
    {
        goldTier = 1;

        wallLimit = 250;
        goldLimit = 1;
        mineLimit = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
