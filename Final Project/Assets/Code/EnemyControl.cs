using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    Transform player;
    NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // StartCoroutine(LookForPlayer());
    }

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(distance < 15)
        {
            _agent.SetDestination(player.position);
            transform.LookAt(player);
        }
        else
        {
            _agent.enabled = false;
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            //Destroy(other.gameObject); // necesscary if bullets/arrows are used
            Destroy(gameObject); // currently enemies are one hit kill
        }
    }

    /*
     *     IEnumerator LookForPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            _agent.SetDestination(player.transform.position);
        }
    }
     */
}
