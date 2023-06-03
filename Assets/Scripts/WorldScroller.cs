using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public SpriteRenderer activeTile1, activeTile2;
    float speed;
    public SpriteRenderer[] allTiles;

    private void FixedUpdate()
    {
        speed = GameManager.Instance.WorldSpeed;

        activeTile1.transform.position += new Vector3( -speed, 0, 0);
        activeTile2.transform.position += new Vector3( -speed, 0, 0);

        if( activeTile2.transform.position.x < 0 )
        {
            Destroy(activeTile1.gameObject);
            activeTile1 = activeTile2;
            var newTile = allTiles[Random.Range(0, allTiles.Length)];
            activeTile2 = Instantiate(newTile, transform);

            activeTile2.transform.position = activeTile1.transform.position + new Vector3( activeTile1.bounds.size.x * 0.5f, 0, 0) + new Vector3(activeTile2.bounds.size.x * 0.5f, 0, 0);
        }
    }

}
