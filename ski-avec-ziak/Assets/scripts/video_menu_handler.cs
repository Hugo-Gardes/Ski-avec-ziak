using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class video_menu_handler : MonoBehaviour
{
    public GameObject ziak;
    public VideoPlayer Intro;

    private void Start() {
        Intro.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp) {
        ziak.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            Intro.Stop();
            ziak.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
