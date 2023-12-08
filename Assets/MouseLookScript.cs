using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    // Start is called before the first frame update
    //x is y, y is x for mouse movement
    public Transform Player;
    public float mouseSensitivity;
    private float camVerticalLook;
    private float camHorizontalLook;
    public float playerMoveSpeed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
        //PlayerMovement();
    }

    private void CameraMovement()
    {
        float mouseXValue = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseYValue = Input.GetAxis("Mouse Y") * mouseSensitivity;
        camVerticalLook -= mouseYValue;
        camVerticalLook = Mathf.Clamp(camVerticalLook, -90f, 60f);
        camHorizontalLook += mouseXValue;
        //camHorizontalLook = Mathf.Clamp(camHorizontalLook, -90f, 90f);
        //transform.localEulerAngles = new Vector3(camVerticalLook, camHorizontalLook, 0f);
        transform.localEulerAngles = new Vector3(camVerticalLook*1f, 0f, 0f);
        //Random.Range(0, camVerticalLook);
        Player.Rotate(Vector3.up * mouseXValue);
    }
    /*private void PlayerMovement()
    {
        float moveForward = Input.GetAxis("Horizontal")*playerMoveSpeed*Time.deltaTime;
        float moveSideways = Input.GetAxis("Vertical")*playerMoveSpeed*Time.deltaTime;
        //Vector3 move = Player.transform.right * moveForward + transform.forward * moveSideways;
        Player.transform.Translate(moveForward,0f,moveSideways);
        
    }*/
}
