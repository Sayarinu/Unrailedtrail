using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    GameObject player;
    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());
    }

    IEnumerator LookForPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(.5f);
            _agent.SetDestination(player.transform.position);
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
}
