using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    float sensitivity = 50;
    float mouseX, mouseY;
    float cameraRotationX, cameraRotationY;
    Vector3 angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKey(KeyCode.W) == true|| Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.S) == true)
        {
          player.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
        }



        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
      

    }
    
}
