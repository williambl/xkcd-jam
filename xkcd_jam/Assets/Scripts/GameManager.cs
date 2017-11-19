using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

        public static GameState state;

        public GameObject win;
        public GameObject lose;

        void Start () {
            state = GameState.PLAYING;
        }

	// Update is called once per frame
	void Update () {
            win.SetActive(state == GameState.WON);
            lose.SetActive(state == GameState.LOST);
	}
}

public enum GameState {
    MENU,
    PLAYING,
    WON,
    LOST
}
