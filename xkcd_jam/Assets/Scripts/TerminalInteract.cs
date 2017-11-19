using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalInteract : MonoBehaviour {

        int playerMask;

        public bool interacted = false;

	// Use this for initialization
	void Start () {
	    playerMask = LayerMask.GetMask("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Use")) {
                if (Physics.CheckSphere(transform.position, 2f, playerMask)) {
                    interacted = true;
                }
            }
	}
}
