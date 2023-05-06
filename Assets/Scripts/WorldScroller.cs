using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public SpriteRenderer activeTile1, activeTile2;
    float speed;

    private void FixedUpdate()
    {
        speed = GameManager.Instance.WorldSpeed;

        activeTile1.transform.position += new Vector3( -speed, 0, 0);
        activeTile2.transform.position += new Vector3( -speed, 0, 0);

        if( activeTile2.transform.position.x < 0 )
        {
            activeTile1.transform.position = activeTile2.transform.position +
                new Vector3( activeTile1.bounds.size.x, 0, 0);

            var tmp = activeTile1;
            activeTile1 = activeTile2;
            activeTile2 = tmp;
        }
    }

}
