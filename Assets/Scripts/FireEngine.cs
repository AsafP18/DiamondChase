using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEngine : MonoBehaviour
{
    public GameObject arrow;
    Animator anm;
    public GameObject forward;
    public GameObject firepoint;
    Transform tempPos;
    GameObject tempArrow;
    float fireRate = 0.8f;
    float nextFire = 0;
    float timer;
    
    float sensitivity = 50;
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Time.time > nextFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timer = Time.time;
                tempArrow = Instantiate(arrow, firepoint.transform.position, arrow.transform.rotation, firepoint.transform);
                tempPos = forward.transform;
                anm.SetTrigger("Draw");
               
            
            }
            if (Input.GetMouseButtonUp(0))
            {
                anm.SetTrigger("Shoot");
                if(tempArrow!=null)
                tempArrow.GetComponent<ArrowEngine>().move = true;
               
                nextFire = Time.time + fireRate;
            }          
            try
            {
                if (timer + 0.8f< Time.time&& tempArrow.transform.parent != null && tempArrow.GetComponent<ArrowEngine>().move==true)
                    tempArrow.transform.parent = null;

            }
            catch (Exception )
            {
                
            }

        }
    }
    
    
    
}
