using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem particles;

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
