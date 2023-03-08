using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainNameSpace;
using System;
using TMPro;

public class element : MonoBehaviour
{
    public GameObject element_;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ForStart", 1.5f);
    }
    private void FixedUpdate()
    {
    }
    // Update is called once per frame
    void ForStart()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        isCollided = false;
}
    void ChangeState()
    {
        gameObject.transform.Find("back").tag = "Unmoving";
    }
    void Update()
    {
        if (gameObject.transform.Find("back").tag == "Moving")
            Invoke("ChangeState", 1.5f);
        Vector2 vector2 = new Vector2(0, 0);

        float x = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float y = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        float x_ = gameObject.GetComponent<Transform>().position.x;
        float y_ = gameObject.GetComponent<Transform>().position.y;

        if (gameObject.transform.Find("back").tag == "Unmoving")
            if (x > -1 && x < 1 && y > -1 && y < 1)
                foreach (var coordi in Main.coordinates)
                {
                    if (Math.Abs(x_ - coordi.x) < 1 && Math.Abs(y_ - coordi.y) < 1)
                    {
                        gameObject.GetComponent<Transform>().position = coordi;
                        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    }
                }

        //检测是否控制方块移动位置
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y);
            if (Main.IfObjectsStop())
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                vector2 = new Vector2(0, 10);
                gameObject.GetComponent<Rigidbody2D>().AddForce(vector2);
                gameObject.transform.Find("back").tag = "Moving";

            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (Main.IfObjectsStop())
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                vector2 = new Vector2(0, -10);
                gameObject.GetComponent<Rigidbody2D>().AddForce(vector2);
                gameObject.transform.Find("back").tag = "Moving";
            }

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (Main.IfObjectsStop())
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                vector2 = new Vector2(10, 0);
                gameObject.GetComponent<Rigidbody2D>().AddForce(vector2);
                gameObject.transform.Find("back").tag = "Moving";
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (Main.IfObjectsStop())
            {
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                vector2 = new Vector2(-10, 0);
                gameObject.GetComponent<Rigidbody2D>().AddForce(vector2);
                gameObject.transform.Find("back").tag = "Moving";
            }
        }
    }
    public bool isCollided = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Numbers")
            if (Convert.ToInt32(collision.gameObject.GetComponentInChildren<TMP_Text>().text) == Convert.ToInt32(gameObject.GetComponentInChildren<TMP_Text>().text))
            {
                if (!collision.gameObject.GetComponent<element>().isCollided)
                {
                    isCollided = true;
                    GameObject gO = Instantiate(gameObject, collision.transform.position, this.transform.rotation);
                    gO.GetComponent<element>().enabled = true;
                    gO.GetComponentInChildren<TextMeshPro>().enabled = true;
                    gO.GetComponentInChildren<TextMeshPro>().text =
                        Convert.ToString(Convert.ToInt32(gameObject.GetComponentInChildren<TextMeshPro>().text) +
                        Convert.ToInt32(collision.gameObject.GetComponentInChildren<TextMeshPro>().text));
                    //gO.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        float x = gameObject.GetComponent<Rigidbody2D>().velocity.x;
        float y = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        float x_ = gameObject.GetComponent<Transform>().position.x;
        float y_ = gameObject.GetComponent<Transform>().position.y;
        if (collision.gameObject.transform.Find("back").tag == "Unmoving")
            if (x > -5 && x < 5 && y > -5 && y < 5)
                foreach (var coordi in Main.coordinates)
                {
                    if (Math.Abs(x_ - coordi.x) < 1 && Math.Abs(y_ - coordi.y) < 1)
                    {
                        gameObject.GetComponent<Transform>().position = coordi;
                        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    }
                }
    }
}
