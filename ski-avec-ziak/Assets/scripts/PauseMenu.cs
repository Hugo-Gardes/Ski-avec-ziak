using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausemenu;
    public global glob;

    private void Start() {
        if (glob == null)
        {
            glob = GameObject.Find("Global").GetComponent<global>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused= false;
        glob.is_run = true;
    }

    void pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale= 0f;
        GameIsPaused= true;
        glob.is_run = false;
    }
}
