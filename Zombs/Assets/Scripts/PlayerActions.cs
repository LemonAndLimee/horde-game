using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Animation punch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            punch.Play();
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;

        Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit)
            {
                if (hit.collider.tag == "Mine")
                {
                    MineLogic mineScript = hit.collider.gameObject.GetComponent<MineLogic>();
                    mineScript.ToggleCanvas();
                }
                else if (hit.collider.tag == "Gold")
                {
                    GoldScript goldScript = hit.collider.gameObject.GetComponent<GoldScript>();
                    goldScript.ToggleCanvas();
                }
                else if (hit.collider.tag == "Wall")
                {
                    WallLogic wallScript = hit.collider.gameObject.GetComponent<WallLogic>();
                    wallScript.ToggleCanvas();
                }
            }
        }
    }
}
