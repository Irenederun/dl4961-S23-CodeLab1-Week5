using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float lowerY = -5.5f;
    private float maxSpeed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowerY)
        {
            transform.position = new Vector3(1.23f, 0f);
            rb2d.velocity = Vector3.zero;
        }

        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = Vector3.ClampMagnitude(rb2d.velocity, maxSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name.Contains("Block"))
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.name.Contains("Door"))
        {
            LevelLoader.Instance.CurrentLevel++;
        }
        
        if (col.gameObject.name.Contains("Trap"))
        {
            Destroy(LevelLoader.Instance.level);
            LevelLoader.Instance.LoadLevel();
        }
    }
}
