using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallLogic : MonoBehaviour
{
	public ScoreLogic scoreScript;
    public ObjectLimits limitScript;

	public int health;
	public int fullHealth;
	public float healthPercentage;
	public Slider healthBar;

	public Canvas canvas;

	public int tier;
	public int requiredStone;
	public int requiredGold;

    public Text tierText;
    public Text upgradeText;
    public Button upgradeButton;

    public int sellingWood;
    public int sellingGold;

    public Text sellText;



	// Start is called before the first frame update
	void Start()
	{
        limitScript = GameObject.Find("GameManager").GetComponent<ObjectLimits>();
        scoreScript = GameObject.Find("GameManager").GetComponent<ScoreLogic>();

        canvas = GetComponentInChildren<Canvas>();
		canvas.enabled = false;

		healthBar = GetComponentInChildren<Slider>();

		health = 150;
		fullHealth = 150;

        tier = 1;
        requiredStone = 2;
        requiredGold = 5;

        sellingWood = 1;
        sellingGold = 0;
	}

	// Update is called once per frame
	void Update()
	{
		healthPercentage = (float)health / (float)fullHealth;
		healthPercentage = healthPercentage * 100f;
		healthBar.value = healthPercentage;

        tierText.text = "Tier " + tier.ToString() + " building";
        if (requiredStone != 0)
        {
            upgradeText.text = "Upgrade (" + requiredStone.ToString() + " stone, " + requiredGold.ToString() + " gold)";
        }
        else
        {
            upgradeText.text = "Upgrade (" + requiredGold.ToString() + " gold)";
        }

        if (limitScript.goldTier <= tier)
        {
            upgradeButton.enabled = false;
            upgradeText.color = new Color(1, 1, 1, 0.5f);
        }
        else if (scoreScript.stone < requiredStone || scoreScript.gold < requiredGold)
        {
            upgradeButton.enabled = false;
            upgradeText.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            upgradeButton.enabled = true;
            upgradeText.color = new Color(1, 1, 1, 1f);
        }



        if (sellingWood != 0)
        {
            sellText.text = "Sell (" + sellingWood.ToString() + " wood)";
        }
        else
        {
            sellText.text = "Sell (" + sellingGold.ToString() + " gold)";
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
