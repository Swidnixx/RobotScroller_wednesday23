using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform activeTile1, activeTile2;
    public float speed = 0.1f;

    private void FixedUpdate()
    {
        activeTile1.position += new Vector3( -speed, 0, 0);
        activeTile2.position += new Vector3( -speed, 0, 0);
    }

}
