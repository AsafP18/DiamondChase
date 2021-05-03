using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform ball;
    float speed;
    Animator anm;
    bool lockedonplayer;//when enemy gets close to player
    bool isAttacking;
    //sizes of box collider
    // Start is called before the first frame update
    void Start()
    {
        speed =3f;
        anm = gameObject.GetComponent<Animator>();
        lockedonplayer = false;
        isAttacking = false;
      //  transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, ball.position) < 10||lockedonplayer)
        {
            if (lockedonplayer == false)
                anm.SetBool("isRunning", true);
            if(isAttacking==false)
                 transform.position = Vector3.MoveTowards(transform.position, new Vector3(ball.position.x,transform.position.y,ball.position.z), speed * Time.deltaTime);
            transform.LookAt(new Vector3(ball.position.x, transform.position.y, ball.position.z));
            lockedonplayer = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anm.SetTrigger("isAttack");
            isAttacking = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            anm.SetTrigger("isAttack");
           // transform.GetComponent<BoxCollider>().enabled = false;
            //transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            anm.SetBool("isRunning", false);
        }
    }
    private IEnumerator OnTriggerExit(Collider other)
    {
        yield return new WaitForSeconds(1.5f);
       // transform.GetComponent<BoxCollider>().enabled = true;
     //   transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        anm.SetBool("isRunning", true);
        isAttacking = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Player")
            print("Plz Have Mercy");
        //reduce hp
    }
}
