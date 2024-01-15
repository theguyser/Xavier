using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startingPosition;
    public float moveSpeed = 0.1f;
    public bool AllowMove = true;
    //private bool canstartcoroutine = false;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position-=new Vector3(0,0,0.01f);
        if (transform.position.z < -222.9f)
        {
            transform.position = startingPosition;
        }*/
    }
    private void FixedUpdate()
    {
        //move the background every 30 seconds, then stop for 10 seconds
        if (AllowMove)
        {
            transform.position -= new Vector3(0, 0, moveSpeed);
            StartCoroutine(Wait());
        }
        else
        {
            StartCoroutine(MoveBackground());
        }
        //reset Position after reaching the end of loop
        if (transform.position.z < -493.2f)
        {
            transform.position = startingPosition;
        }
    }
    //coroutine that determines whether the background should move or not
    
    IEnumerator MoveBackground()
    {
        yield return new WaitForSeconds(10f);
        AllowMove = true;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        AllowMove= false;
    }
}
