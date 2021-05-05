using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Animator anm;
    bool lockedonplayer;//when enemy gets close to player
    bool isAttacking;
   
    //sizes of box collider
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anm = gameObject.GetComponent<Animator>();
        lockedonplayer = false;
        isAttacking = false;
      //  transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10||lockedonplayer)
        {
            if (isAttacking == false)
            {
                anm.SetBool("isRunning", true);
                GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            }
            lockedonplayer = true;
             transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

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
            anm.SetBool("isRunning", false);
        }
    }
    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            yield return new WaitForSeconds(1.5f);
            anm.SetBool("isRunning", true);
            isAttacking = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Player")
            print("Plz Have Mercy");
        //reduce hp
    }
}
