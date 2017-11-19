using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

        public static GameState state;

        public GameObject win;
        public GameObject lose;
        public GameObject pause;

        public Button resume;
        public Button restart;
        public Button quit;

        public AudioSource src;

        void Start () {
            state = GameState.PLAYING;
            resume.onClick.AddListener(TogglePause);
            restart.onClick.AddListener(StartGame);
            quit.onClick.AddListener(Quit);
        }

	// Update is called once per frame
	void Update () {
            win.SetActive(state == GameState.WON);
            lose.SetActive(state == GameState.LOST);
            pause.SetActive(state == GameState.PAUSED);

            if (Input.GetButtonDown("Cancel")) {
                TogglePause();
            }
        }

        public void TogglePause () {
            src.Play();
            if (state == GameState.PLAYING)
                state = GameState.PAUSED;
            else if (state == GameState.PAUSED)
                state = GameState.PLAYING;
        }

        public void StartGame () {
            src.Play();
            SceneManager.LoadScene(1);
        }

        public void Quit () {
            src.Play();
            SceneManager.LoadScene(0);
        }
}

public enum GameState {
    MENU,
    PLAYING,
    WON,
    LOST,
    PAUSED
}
