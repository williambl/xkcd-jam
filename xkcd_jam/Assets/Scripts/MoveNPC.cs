using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class MoveNPC : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;
    public Transform[] points;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
        anim = GetComponent<Animator> ();
        Patrol();
    }

    void Update () {
        if (agent.remainingDistance < 0.1)
            Patrol();

        Vector3 movementDir = Vector3.zero;
        anim.SetBool("isMoving", movementDir != Vector3.zero);
        anim.SetFloat("velocityX", movementDir.x);
        anim.SetFloat("velocityZ", movementDir.z);
    }

    void Patrol () {
        agent.destination = points[Random.Range(0, points.Length-1)].position;
    }
}
