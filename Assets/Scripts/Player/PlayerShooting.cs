using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;
    float nextShot;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShot)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextShot = Time.time + fireRate;
        }
    }
}