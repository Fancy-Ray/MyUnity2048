using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainNameSpace;
using System;

public class element : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = new Vector2(0,0);
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
            if (Main.IfObjectsStop())
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10));
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (Main.IfObjectsStop())
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10));
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (Main.IfObjectsStop())
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 0));
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (Main.IfObjectsStop())
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0));
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity == vector2) {
            gameObject.GetComponent<Transform>().transform.position.x = Math.Round(gameObject.GetComponent<Transform>().transform.position.x, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vector2 = new Vector2(0, 0);
        if (collision.gameObject.tag == "Numbers")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity == vector2)
                gameObject.GetComponent<Rigidbody2D>().velocity = vector2;
        }
    }
}
