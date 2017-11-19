using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalManager : MonoBehaviour {

        public TerminalInteract[] terminals;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	   if (CheckTerminals())
              Debug.Log("Win!");
	}

        bool CheckTerminals () {
            foreach (TerminalInteract terminal in terminals) {
                if (!terminal.interacted) {
                    Debug.Log("No");
                    return false;
                }
            }
            return true;
        }
}
