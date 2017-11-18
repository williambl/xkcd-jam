using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class Move : MonoBehaviour {

    CharacterController controller;
    Animator anim;
    public float speed = 6.0f;

    void Start () {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
    }

    void Update () {
        Vector3 movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDir = transform.TransformDirection(movementDir);
        movementDir *= speed;
        controller.SimpleMove(movementDir);
        anim.SetBool("isMoving", movementDir != Vector3.zero);
    }
}
