using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject forward, left, right, back;
    float speed;
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(right.transform.position.x, transform.position.y, right.transform.position.z), speed * Time.deltaTime);
            anm.SetBool("RightWalk", true);
            anm.SetBool("LeftWalk", false);
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(left.transform.position.x, transform.position.y, left.transform.position.z), speed * Time.deltaTime);
            anm.SetBool("LeftWalk", true);
            anm.SetBool("RightWalk", false);
        }
        else
        {
            anm.SetBool("LeftWalk", false);
            anm.SetBool("RightWalk", false);
        }
        if (Input.GetKey(KeyCode.W) == true)
        {        
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(forward.transform.position.x, transform.position.y, forward.transform.position.z), speed * Time.deltaTime);
            anm.SetBool("ForwardWalk", true);
            anm.SetBool("BackWalk", false);
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(back.transform.position.x, transform.position.y, back.transform.position.z), speed * Time.deltaTime);
            anm.SetBool("BackWalk", true);
            anm.SetBool("ForwardWalk", false);
        }
        else
        {
            anm.SetBool("ForwardWalk", false);
            anm.SetBool("BackWalk", false);
        }
    }
}
