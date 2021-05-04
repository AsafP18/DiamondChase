using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEngine : MonoBehaviour
{
    public bool move;
    Transform forward;
    bool first;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
        first = true;
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(move&&timer+1>Time.time)
        {
            StartMove();
        }
        else if(move&& timer + 1 < Time.time)
        {
            StartMove();
            first = false;
        }
    }
    public void SetForward(Transform forward)
    {
        this.forward = forward;
    }
    public IEnumerator StartMove()
    {
        if(first)
        {
            yield return new WaitForSeconds(timer-Time.time);
                       
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(forward.transform.position.x, transform.position.y, forward.transform.position.z), 20 * Time.deltaTime);
            first = false;
        }
        else
        {
            
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(forward.transform.position.x, transform.position.y, forward.transform.position.z), 20 * Time.deltaTime);
        }
    }
}
