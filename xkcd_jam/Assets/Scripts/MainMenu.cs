﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

        public Text title;
        public Button play;
        public Button quit;
        public AudioSource src;

	// Use this for initialization
	void Start () {
	    StartCoroutine(BlinkCursor ());
            play.onClick.AddListener(Play);
            quit.onClick.AddListener(Quit);
	}
	
	void Play () {
            src.Play();
	    SceneManager.LoadScene(1);
	}

        void Quit () {
            src.Play();
            Application.Quit();
        }

        IEnumerator BlinkCursor () {
            while (true) {
                title.text = "$ UPTIME_";
                yield return new WaitForSeconds(1f);
                title.text = "$ UPTIME";
                yield return new WaitForSeconds(1f);
            }
        }
}
