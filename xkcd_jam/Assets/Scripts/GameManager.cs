using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

        public static GameState state;

        public GameObject win;
        public GameObject lose;
        public GameObject pause;

        void Start () {
            state = GameState.PLAYING;
        }

	// Update is called once per frame
	void Update () {
            win.SetActive(state == GameState.WON);
            lose.SetActive(state == GameState.LOST);
            pause.SetActive(state == GameState.PAUSED);

            if (Input.GetButtonDown("Cancel")) {
                if (state == GameState.PLAYING)
                    state = GameState.PAUSED;
                else if (state == GameState.PAUSED)
                    state = GameState.PLAYING;
            }
	}
}

public enum GameState {
    MENU,
    PLAYING,
    WON,
    LOST,
    PAUSED
}
