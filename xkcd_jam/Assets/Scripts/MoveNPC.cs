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

    LineRenderer line;
    AudioSource src;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        anim = GetComponent<Animator> ();
        line = GetComponent<LineRenderer> ();
        src = GetComponent<AudioSource>();
        line.enabled = false;
        Patrol();
    }

    void Update () {
        if (GameManager.state != GameState.PLAYING) {
            agent.destination = transform.position;
            return;
        }
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
            if (GameManager.state != GameState.PLAYING)
                yield return new WaitForSeconds(1f);
            line.enabled = false;
            RaycastHit hit;
            Vector3 position = transform.position + new Vector3(0,1,0);
            Vector3 direction = player.position - transform.position;

            if (Physics.Raycast(position, direction, out hit)) {
                Debug.DrawLine(position, hit.point, Color.cyan, 2f);

                if(hit.collider.gameObject.tag == "Player") {
                    hit.collider.GetComponent<PlayerHealth>().LoseHealth(1f);
                    line.SetPositions(new []{position, hit.point});
                    line.enabled = true;
                    src.Play();
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
