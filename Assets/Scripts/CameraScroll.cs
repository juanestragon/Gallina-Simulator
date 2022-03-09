using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public Transform player;

    public float smoothtime = 0.3f;
    public float posy;
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    public SpriteRenderer spriteRenderer;
    float xmore;
    public float xmoreasiggnement;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (spriteRenderer.flipX == true)
        {
            xmore = xmoreasiggnement;
        }
        else
        {
            xmore = -xmoreasiggnement;
        }
        Vector3 playerPosition = player.TransformPoint(new Vector3(xmore, posy, -10));
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothtime);
        transform.position = new Vector3 (Mathf.Clamp (desiredPosition.x, minx, maxx), Mathf.Clamp(desiredPosition.y, miny, maxy), desiredPosition.z);
    }
}
