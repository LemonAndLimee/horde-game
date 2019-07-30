using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector3 upForce;
    public Vector3 leftForce;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(upForce);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-upForce);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(leftForce);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(-leftForce);
        }

        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;

    }
}
