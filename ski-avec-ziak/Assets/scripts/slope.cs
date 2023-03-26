using UnityEngine;

public class SlopeMovement : MonoBehaviour
{
    public Terrain slope;
    public depla depal;
    public float x = 3;
    public int z = 2;

    public void Slide(int dir)
    {
        Vector3 pos = slope.transform.position;
        Debug.Log(pos);

        if (dir == 1)
            pos.x -= z;
        if (dir == 2)
            pos.x += z;
        pos.z -= x;

        Debug.Log(pos);

        slope.transform.position = pos;
    }

    public void Update()
    {
        Slide(depal.getDir());
    }
}