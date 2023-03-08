using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace MainNameSpace
{
    public class Main : MonoBehaviour
    {
        public  GameObject element;
        public static Vector3[] coordinates = {
            new Vector3(-3, 3), new Vector3(-1, 3), new Vector3(1, 3), new Vector3(3,3) ,
            new Vector3(-3, 1), new Vector3(-1, 1), new Vector3(1, 1), new Vector3(3,1) ,
            new Vector3(-3, -1), new Vector3(-1, -1), new Vector3(1, -1), new Vector3(3,-1) ,
            new Vector3(-3, -3), new Vector3(-1, -3), new Vector3(1, -3), new Vector3(3,-3) ,

        };
        // Start is called before the first frame update
        void Start()
        {
            Instantiate(element, RandomIdleCoordinate(), this.transform.rotation);
        }

        // Update is called once per frame
        void Update()
        {
            if(gameObject.transform.Find("back").tag == "Moving")
                Invoke("ChangeState", 1.5f);
            if (Input.GetKeyUp(KeyCode.UpArrow) ||
    Input.GetKeyUp(KeyCode.DownArrow) ||
    Input.GetKeyUp(KeyCode.RightArrow) ||
    Input.GetKeyUp(KeyCode.LeftArrow))
            {
                gameObject.transform.Find("back").tag = "Moving";
                if (IfObjectsStop())
                {
                    Instantiate(element, RandomIdleCoordinate(), this.transform.rotation);
                }
            }
        }
        void ChangeState() {
            gameObject.transform.Find("back").tag = "Unmoving";
        }
        private void FixedUpdate()
        {



        }
        public static bool IfObjectsStop()
        {
            foreach (var gO in GameObject.FindGameObjectsWithTag("Numbers"))
            {
                //float x = gO.GetComponent<Rigidbody2D>().velocity.x;
                //float y = gO.GetComponent<Rigidbody2D>().velocity.y;
                //if (x < -1 && x > 1 && y < -1 && y > 1)
                //if(gO.GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezeAll)

                if (gO.GetComponent<Rigidbody2D>().velocity != Vector2.zero)

                return false;
            }
            return true;
        }
        public static bool IfObjectsNearlyStop()
        {
            foreach (var gO in GameObject.FindGameObjectsWithTag("Numbers"))
            {
                float x = gO.GetComponent<Rigidbody2D>().velocity.x;
                float y = gO.GetComponent<Rigidbody2D>().velocity.y;
                if (x < -1 && x > 1 && y < -1 && y > 1)
                    return false;
            }
            return true;
        }
        public static void OrganizePositions()
        {
            foreach (var gO in GameObject.FindGameObjectsWithTag("Numbers"))
            {
                float x = gO.GetComponent<Transform>().position.x;
                float y = gO.GetComponent<Transform>().position.y;
                foreach (var coordi in Main.coordinates)
                {
                    if (Math.Abs(x - coordi.x) < 1 && Math.Abs(y - coordi.y) < 1)
                    {
                        gO.GetComponent<Transform>().position = coordi;
                        gO.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    }
                }
            }
        }
        //private Vector3 RandomIdleCoordinate()
        public static Vector3 RandomIdleCoordinate()
        {
            int index = 0;
            //for (index=0; index < coordinates.Length; index++) 
            while (index < coordinates.Length)
            {
                Labell:
                foreach (var gO in GameObject.FindGameObjectsWithTag("Numbers"))
                {
                    if (gO.GetComponent<Transform>().transform.position.x != coordinates[index].x || gO.GetComponent<Transform>().transform.position.y != coordinates[index].y)
                        //这里可以这样写，因为所有的坐标引用都是指向的Coordinates数组中的对象
                        ;
                    else
                    {
                        index++;
                        goto Labell;
                    }
                }
                return coordinates[index];
            }
            return coordinates[index];
        }

    }
}
