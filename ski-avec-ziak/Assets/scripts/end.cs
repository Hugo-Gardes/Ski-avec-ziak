using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end : MonoBehaviour
{
    public TMP_Text test;
    public HUD hud;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        test.text = "in : " + hud.time.ToString("F3");
    }
}
