using UnityEngine;

public class PhysicRaycastCamera : MonoBehaviour
{
    RaycastHit hit;
    int mask;

    private void Awake()
    {
        mask = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 100f, mask))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        
    }
}
