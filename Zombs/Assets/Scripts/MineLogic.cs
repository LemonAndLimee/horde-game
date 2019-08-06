using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineLogic : MonoBehaviour
{
	public ScoreLogic scoreScript;
    public ObjectLimits limitScript;

    public int goldPerSecond;

	public float timer;

    public int health;
    public int fullHealth;
    public float healthPercentage;
    public Slider healthBar;

    public Canvas canvas;

    public int tier;
    public int requiredWood;
    public int requiredStone;
    public int requiredGold;

    public Text tierText;
    public Text upgradeText;
    public Button upgradeButton;

    public int sellingWood;
    public int sellingStone;
    public int sellingGold;

    public Text sellText;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;

        limitScript = GameObject.Find("GameManager").GetComponent<ObjectLimits>();
        scoreScript = GameObject.Find("GameManager").GetComponent<ScoreLogic>();
        goldPerSecond = 4;

        healthBar = GetComponentInChildren<Slider>();

        health = 150;
        fullHealth = 150;

        tier = 1;
        requiredWood = 5;
        requiredStone = 5;
        requiredGold = 0;

        sellingWood = 2;
        sellingStone = 2;
        sellingGold = 0;

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

        tierText.text = "Tier " + tier.ToString() + " building";
        if (requiredGold != 0)
        {
            upgradeText.text = "Upgrade (" + requiredWood.ToString() + " wood, " + requiredStone.ToString() + " stone, " + requiredGold.ToString() + " gold)";
        }
        else
        {
            upgradeText.text = "Upgrade (" + requiredWood.ToString() + " wood, " + requiredStone.ToString() + " stone)";
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



        if (sellingGold != 0)
        {
            sellText.text = "Sell (" + sellingWood.ToString() + " wood, " + sellingStone.ToString() + " stone, " + sellingGold.ToString() + " gold)";
        }
        else
        {
            sellText.text = "Sell (" + sellingWood.ToString() + " wood, " + sellingStone.ToString() + " stone)";
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
