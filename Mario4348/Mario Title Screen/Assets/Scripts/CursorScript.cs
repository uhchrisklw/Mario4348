using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour {

    public GameObject startCursor;
    public GameObject exitCursor;
    public AudioSource soundSource;
    public string nextSceneLoad;

    private GameObject activeCursor;

    void Start() {
        activeCursor = startCursor;
    }

    void Update () {
        if((Input.GetKeyDown("down") || Input.GetKeyDown("s")) && activeCursor == startCursor) {
            soundSource.Play();

            exitCursor.SetActive(true);
            activeCursor = exitCursor;

            startCursor.SetActive(false);
        }

        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && activeCursor == exitCursor) {
            soundSource.Play();

            startCursor.SetActive(true);
            activeCursor = startCursor;

            exitCursor.SetActive(false);
        }

        if(Input.GetKeyDown("space")) {
            if (activeCursor == startCursor) {
                SceneManager.LoadScene(nextSceneLoad);
            }

            if(activeCursor == exitCursor) {
                Debug.Log("Exiting game...");
                Application.Quit();
            }
        }
	}
}
