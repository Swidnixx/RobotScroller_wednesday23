using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem particles;
    public float speed = 1;
    Transform player;

    public float maxDistance = 1;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        if(GameManager.Instance.MagnetActive)
        {
            if (Vector2.Distance(transform.position, player.position) < maxDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.CollectCoin(); //Naliczanie coinów w GM
            Destroy(gameObject);

            Vector3 scale = particles.transform.localScale;
            particles.transform.SetParent(transform.parent, true);
            particles.transform.localScale = transform.parent.InverseTransformDirection(scale);
            particles.Play();
            Destroy(particles.gameObject, 1);

        }
    }
}
