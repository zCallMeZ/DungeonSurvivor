using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float speed = 1f; //TODO(@Bryan) This is a float, be specific and indicate that it's a float.
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    private float bulletForce = 15f;
    private float fireRate;
    private float nextFire;

    //[SerializeField] AudioSource bulletSound;
    void Start()
    {
        fireRate = 0.5f; //TODO(@Bryan) Assign the value when declaring the variable.
        nextFire = Time.time;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shooting();
        }
    }

    void Shooting()
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
