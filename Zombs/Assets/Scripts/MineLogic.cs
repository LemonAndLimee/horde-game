using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineLogic : MonoBehaviour
{
	public ScoreLogic scoreScript;

	public int goldPerSecond;

	public float timer;

    public int health;
    public int fullHealth;
    public float healthPercentage;
    public Slider healthBar;

    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;

		scoreScript = GameObject.Find("GameManager").GetComponent<ScoreLogic>();
        goldPerSecond = 4;

        healthBar = GetComponentInChildren<Slider>();

        health = 150;
        fullHealth = 150;


    }

    // Update is called once per frame
    void Update()
    {
        healthPercentage = (float)health / (float)fullHealth;
        healthPercentage = healthPercentage * 100f;
        healthBar.value = healthPercentage;

        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            scoreScript.gold += goldPerSecond;
            timer = 0f;
        }


    }

    public void ToggleCanvas()
    {
        if (canvas.enabled == false)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
