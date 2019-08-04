using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLogic : MonoBehaviour
{
    public int wood;
    public int stone;
    public int gold;

    public Text woodText;
    public Text stoneText;
    public Text goldText;

    public int health;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        goldText.text = gold.ToString();

        healthBar.value = health;
    }

    public void Add(int type, int amount)
    {
        if (type == 0)
        {
            wood += amount;
        }
        else if (type == 1)
        {
            stone += amount;
        }
        else if (type == 2)
        {
            gold += amount;
        }
    }
}
