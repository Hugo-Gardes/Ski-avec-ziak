using UnityEngine;

public class SlopeMovement : MonoBehaviour
{
    public Terrain slope;
    public depla depal;
    public float x = 3;
    public int z = 2;
    public global glob;
    private float x_base = 0f;

    private void Start()
    {
        if (glob == null)
        {
            glob = GameObject.Find("Global").GetComponent<global>();
        }
        x_base = x;
    }

    public void Slide(int dir)
    {
        if (dir == 1)
            slope.transform.Translate(Vector3.right * -z * Time.deltaTime);
        if (dir == 2)
            slope.transform.Translate(Vector3.right * z * Time.deltaTime);
        slope.transform.Translate(Vector3.back * x * Time.deltaTime);
    }

    public void upSpeed()
    {
        float par = depal.getPar();
        float p = 1f - par;

        x = x_base * p;
    }

    public void FixedUpdate()
    {
        if (!glob.is_run)
            return;
        upSpeed();
        Slide(depal.getDir());
    }
}