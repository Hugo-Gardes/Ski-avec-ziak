using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercollide : MonoBehaviour
{
    bool is_ok = false;
    public GameObject end;
    public GameObject death;
    public GameObject end_obj;
    public GameObject player;
    public global glob;

    private void Start() {
        if (glob == null)
        {
            glob = GameObject.Find("Global").GetComponent<global>();
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision");
        if (other.gameObject.tag == "tree") {
            Debug.Log("Tree");
        }
    }

    private void FixedUpdate() {
        if (player.transform.position.z > end_obj.transform.position.z) {
            Debug.Log("End");
            end.SetActive(true);
            glob.is_run = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!is_ok) {
            is_ok = true;
            return;
        }
        Debug.Log("Trigger, " + other.gameObject.tag);
        Debug.Log("Death");
        death.SetActive(true);
        glob.is_run = false;
    }
}
