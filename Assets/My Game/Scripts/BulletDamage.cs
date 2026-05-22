using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;
    public GameObject hitPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
    void CreateBulletImpactPrefab(Collision collision)
    {
        ContactPoint contactPoint = collision.contacts[0];
        GameObject hole = Instantiate(hitPrefab, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));
        hole.transform.SetParent(collision.transform);
    }
}
