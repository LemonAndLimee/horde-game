﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallLogic : MonoBehaviour
{
	public ScoreLogic scoreScript;

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

		healthBar = GetComponentInChildren<Slider>();

		health = 1500;
		fullHealth = 1500;
	}

	// Update is called once per frame
	void Update()
	{
		healthPercentage = (float)health / (float)fullHealth;
		healthPercentage = healthPercentage * 100f;
		healthBar.value = healthPercentage;
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