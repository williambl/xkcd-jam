using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class Move : MonoBehaviour {

    CharacterController controller;
    public float speed = 6.0f;

    void Start () {
        controller = GetComponent<CharacterController> ();
    }

    void Update () {
        if (!controller.isGrounded)
            return;

        Vector3 movementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDir = transform.TransformDirection(movementDir);
        movementDir *= speed;
        controller.SimpleMove(movementDir);
    }
}
