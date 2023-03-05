using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardFollow : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 objPos;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
       UpdateTransform();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            objPos.x -= speed * Time.deltaTime;
            transform.position = objPos;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            objPos.x += speed * Time.deltaTime;
            transform.position = objPos;
        }
        UpdateTransform();
    }

    private void UpdateTransform()
    {
        objPos = transform.position;
    }
}
