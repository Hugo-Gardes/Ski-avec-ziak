using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject fasttext;
    public TMP_Text speedtext;
    public TMP_Text degres;
    public TMP_Text timetext;
    private float speed;
    private float leftski;
    private float rightski;
    private float time;
    public bool timerActive = false;
    public global glob;
    public depla depal;
    public SlopeMovement slope;

    void Start()
    {
        if (glob == null)
        {
            glob = GameObject.Find("Global").GetComponent<global>();
        }
    }
    void FixedUpdate()
    {
        if (!glob.is_run)
            return;
        if (timerActive) {
            time += Time.deltaTime;
            timetext.text = "Time: " + time.ToString("F3");
        }
        getdegres();
        getspeed();
    }

    public void getspeed()
    {
        float sp = slope.x * 4.69f;
        speedtext.text = sp.ToString("F1") + "Km/h";
    }

    public void getdegres()
    {
        Debug.Log(depal.getPar());
        float nb = depal.getPar();
        if (nb == 1) {
            nb = depal.max_angle;
        } else if (nb == 0) {
            nb = depal.min_angle;
        } else {
            nb *= depal.max_angle;
        }
        degres.text = nb.ToString("F2") + "°";
    }

    public void fast()
    {
        if (speed >= 45)
        {
            fasttext.SetActive(true);
        }
    }
}
