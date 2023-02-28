using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace MainNameSpace
{
    public class Main : MonoBehaviour
    {
        public GameObject element;
        Vector3[] coordinates = {
            new Vector3(-3, 3), new Vector3(-1, 3), new Vector3(1, 3), new Vector3(3,3) ,
            new Vector3(-3, 1), new Vector3(-1, 1), new Vector3(1, 1), new Vector3(3,1) ,
            new Vector3(-3, -1), new Vector3(-1, -1), new Vector3(1, -1), new Vector3(3,-1) ,
            new Vector3(-3, -3), new Vector3(-1, -3), new Vector3(1, -3), new Vector3(3,-3) ,

        };
        // Start is called before the first frame update
        void Start()
        {
            Instantiate(element, coordinates[0], this.transform.rotation);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) ||
                Input.GetKeyUp(KeyCode.DownArrow) ||
                Input.GetKeyUp(KeyCode.RightArrow) ||
                Input.GetKeyUp(KeyCode.LeftArrow)) {
                if (IfObjectsStop()) {
                    Instantiate(element, randomIdleCoordinate(), this.transform.rotation);
                }
            }
        }
        public static bool IfObjectsStop()
        {
            Vector2 vector2 = new Vector2(0, 0);
            foreach (var gO in GameObject.FindGameObjectsWithTag("Numbers")) {
                if (gO.GetComponent<Rigidbody2D>().velocity != vector2)
                    return false;
            }
            return true;
        }
        private Vector3 randomIdleCoordinate() {
            foreach (var gO in GameObject.FindGameObjectsWithTag("Numbers")) {
                foreach (var gOCoor in coordinates)
                {
                    if (gO.GetComponent<Transform>().transform.position.Equals(gOCoor))
                        //这里可以这样写，因为所有的坐标引用都是指向的Coordinates数组中的对象
                        break;
                    else
                        return gOCoor;
                }
            }
            return new Vector3(0,0);
        }

    }
}
