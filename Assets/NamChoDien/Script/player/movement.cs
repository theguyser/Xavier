using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    void Update()
    {
        //Move forward
      transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //Move left 
      if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
      {
          if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
          {
              transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
          }
      }
        //Move right
      if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
      {
          if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
          {
              transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
          }
      }
    }
    
}
