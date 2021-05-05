using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEngine : MonoBehaviour
{
    
    GameObject forward;
    public bool move;
    float timer;
   // bool Inair;
    // Start is called before the first frame update
    void Start()
    {

        move = false;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if( timer + 1.5f < Time.time&&move)
        {
            //Inair = true;
            if(forward==null)
            forward=GameObject.Find("ShootLine");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(forward.transform.position.x, forward.transform.position.y, forward.transform.position.z), 20 * Time.deltaTime);
        }
 
        try
        {
            if (transform.position == forward.transform.position)
                Destroy(gameObject);

        }
        catch (Exception)
        {

        }
    }
   
   
}
