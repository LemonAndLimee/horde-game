using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLogic : MonoBehaviour
{
	public ScoreLogic scoreScript;

	public int goldPerSecond;

	public float Timer;


    // Start is called before the first frame update
    void Start()
    {
		scoreScript = GameObject.Find("GameManager").GetComponent<ScoreLogic>();
    }

    // Update is called once per frame
    void Update()
    {
		
    }
}
