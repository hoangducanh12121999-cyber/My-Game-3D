using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum ShootingMode
    {
        Single,
        Burst,
        Auto
    }
    public enum WeaponModel
    {
        Pistol,
        Rifle,
    }
    public ShootingMode currentShootingMode = ShootingMode.Auto;
    public WeaponModel currentWeaponModel;
    [Header("Bullet")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab; 
    public float bulletSpeed = 500f;
    private int layerMask;
    private bool isShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerMask = ~LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShootingMode == ShootingMode.Auto)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }
        else if (currentShootingMode == ShootingMode.Burst || currentShootingMode == ShootingMode.Single)
        {
           isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if (isShooting)
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        Vector3 shootingDirection = CalculateDirectionAndSpread().normalized;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.transform.forward = bulletSpawn.forward;
        bullet.GetComponent<Rigidbody>().linearVelocity = shootingDirection * bulletSpeed * Time.deltaTime; 
    }

    private Vector3 CalculateDirectionAndSpread()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            targetPoint = hit.point;
            Debug.Log("Hit: " + hit.collider.gameObject.name);
        }
        else
        {
            targetPoint = ray.GetPoint(1000f);
        }
        Vector3 direction = targetPoint - bulletSpawn.position;
        return direction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(bulletSpawn.position, bulletSpawn.position + CalculateDirectionAndSpread().normalized * 100f);
    }
}
