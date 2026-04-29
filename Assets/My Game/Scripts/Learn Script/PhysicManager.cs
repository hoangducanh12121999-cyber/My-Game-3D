using UnityEngine;

public class PhysicManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collidered with: " + collision.gameObject.name);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit Collidered with: " + collision.gameObject.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay Collidered with: " + collision.gameObject.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered with: " + other.gameObject.name);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited with: " + other.gameObject.name);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger Stayed with: " + other.gameObject.name);
    }
}

