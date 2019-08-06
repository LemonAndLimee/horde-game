using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour
{
	public ScoreLogic scoreScript;
    public ObjectLimits limitScript;

    public int health;
	public int fullHealth;
	public float healthPercentage;
	public Slider healthBar;

	public Canvas canvas;

    public int tier;
    public int requiredGold;

    public Text tierText;
    public Text upgradeText;
    public Button upgradeButton;

    // Start is called before the first frame update
    void Start()
    {
        limitScript = GameObject.Find("GameManager").GetComponent<ObjectLimits>();
        scoreScript = GameObject.Find("GameManager").GetComponent<ScoreLogic>();

        canvas = GetComponentInChildren<Canvas>();
		canvas.enabled = false;

		healthBar = GetComponentInChildren<Slider>();

		health = 1500;
		fullHealth = 1500;

        tier = 1;
        requiredGold = 5000;
	}

    // Update is called once per frame
    void Update()
    {
		healthPercentage = (float)health / (float)fullHealth;
		healthPercentage = healthPercentage * 100f;
		healthBar.value = healthPercentage;

        tierText.text = "Tier " + tier.ToString() + " building";
        upgradeText.text = "Upgrade (" + requiredGold.ToString() + " gold)";

        if (scoreScript.gold < requiredGold)
        {
            upgradeButton.enabled = false;
            upgradeText.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            upgradeButton.enabled = true;
            upgradeText.color = new Color(1, 1, 1, 1f);
        }

        limitScript.goldTier = tier;
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
