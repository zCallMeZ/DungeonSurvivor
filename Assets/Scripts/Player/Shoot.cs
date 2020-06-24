using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private float bulletForce = 15.0f;
    private float fireRate = 0.5f;
    private float nextFire;

    //[SerializeField] AudioSource bulletSound;
    private void Start()
    {
        nextFire = Time.time;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                //bulletSound.Play();
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                nextFire = Time.time + fireRate;
            }
        }
    }
}
