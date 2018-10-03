using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour {

    public AudioSource bgMusicSource;
    private bool audioBegin = false;

    void Awake() {
        if(!audioBegin) {
            bgMusicSource.Play();
            DontDestroyOnLoad(gameObject);
            audioBegin = true;
        }
    }
}
