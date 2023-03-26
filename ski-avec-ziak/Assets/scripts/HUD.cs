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

    void Start()
    {
        
    }
    void Update()
    {
        if (timerActive) {
            time += Time.deltaTime;
            timetext.text = "Time: " + time.ToString("F3");
        }
    }

    public void getspeed()
    {
        speedtext.text = speed.ToString() + "Km/h";
    }

    public void getdegres()
    {
        float nb = leftski - rightski;
        if (nb < 0)
            nb = nb * -1;
        degres.text = nb.ToString();
    }

    public void fast()
    {
        if (speed >= 45)
        {
            fasttext.SetActive(true);
        }
    }
}
