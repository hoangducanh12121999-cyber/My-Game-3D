using System;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            CreateExplosionPrefabs(collision);
            Destroy(gameObject);
        }
    }

    private void CreateExplosionPrefabs(Collision collision)
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
