using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depla : MonoBehaviour
{
    public float vitesse = 10f;
    public KeyCode[] inputs;
    public float max_angle = 45f;
    public float min_angle = -45f;
    private global glob;
    private float deplacementLateral = 0f;
    GameObject obj2;

    void Start()
    {
        if (gameObject.name == "Left")
        {
            obj2 = GameObject.Find("Right");
        }
        else
        {
            obj2 = GameObject.Find("Left");
        }
        if (obj2 == null)
        {
            Debug.LogError("obj2 is null");
        }
        if (glob == null)
        {
            glob = GameObject.Find("Global").GetComponent<global>();
        }
    }

    public float getPar()
    {
        if (obj2 == null)
        {
            return 0f;
        }

        // Calculer l'angle entre les deux rotations des skis
        float angleBetween = Quaternion.Angle(transform.rotation, obj2.transform.rotation);

        // Normaliser l'angle entre -1 et 1 en le divisant par la valeur maximale possible
        float normalizedAngle = Mathf.Clamp(angleBetween / (max_angle - min_angle), -1f, 1f);

        return normalizedAngle;
    }

    void FixedUpdate()
    {
        if (!glob.is_run)
            return;
        if (Input.GetKey(inputs[0]))
        {
            deplacementLateral = -vitesse;
        }
        else if (Input.GetKey(inputs[1]))
        {
            deplacementLateral = vitesse;
        }
        else
        {
            deplacementLateral = 0f;
        }

        float newRotation = transform.rotation.eulerAngles.y + deplacementLateral * Time.deltaTime;
        if (newRotation > 180f)
        {
            newRotation -= 360f;
        }

        float clampedRotation = Mathf.Clamp(newRotation, min_angle, max_angle);
        Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, clampedRotation, transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * vitesse);
    }

    public short getDir() {
        if (transform.rotation.z > 0 && obj2.transform.rotation.z >= 0)
            return (1);
        else if (transform.rotation.z < 0 && obj2.transform.rotation.z <= 0)
            return (2);
        return (0);
    }

    void Update()
    {
        if (!glob.is_run)
            return;
        getPar();
        if (getDir() == 1)
            Debug.Log("Right");
        else if (getDir() == 2)
            Debug.Log("Left");
        else if (getDir() == 0) {
            Debug.Log("Straight");
        }
    }
}
