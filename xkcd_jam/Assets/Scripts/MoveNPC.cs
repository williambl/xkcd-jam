using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class MoveNPC : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;
    public Transform[] points;
    public Transform player;
    bool isChasingPlayer;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        anim = GetComponent<Animator> ();
        Patrol();
    }

    void Update () {
        if (Vector3.Distance(transform.position, player.position) < 10) {
            if (!isChasingPlayer)
                StartCoroutine(Shoot ());

            if (Vector3.Distance(transform.position, player.position) < 3)
                agent.destination = transform.position;
            else
                agent.destination = player.position;
            isChasingPlayer = true;
        } else {
            if (isChasingPlayer)
                StopCoroutine(Shoot ());
            isChasingPlayer = false;
        }

        if (!isChasingPlayer && agent.remainingDistance < 0.1)
            Patrol();

        Vector3 movementDir = Vector3.zero;
        anim.SetBool("isMoving", movementDir != Vector3.zero);
        anim.SetFloat("velocityX", movementDir.x);
        anim.SetFloat("velocityZ", movementDir.z);
    }

    void Patrol () {
        agent.destination = points[Random.Range(0, points.Length-1)].position;
    }

    IEnumerator Shoot () {
        while (true) {
            RaycastHit hit;
            Vector3 position = transform.position + new Vector3(0,1,0);
            if (Physics.Raycast(position, transform.forward, out hit)) {
                Debug.DrawLine(position, hit.point, Color.cyan, 2f);
                if(hit.collider.gameObject.tag == "Player") {
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
