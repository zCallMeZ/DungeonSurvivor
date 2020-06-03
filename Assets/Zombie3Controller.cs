using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Zombie3Controller : MonoBehaviour
{
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    [SerializeField] Transform point3;
    [SerializeField] Transform point4;

    bool followPoint1 = true;
    bool followPoint2 = false;
    bool followPoint3 = false;
    bool followPoint4 = false;

    Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (followPoint1)
        {
            Vector3 direction = point1.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        if (followPoint2)
        {
            Vector3 direction = point2.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        if (followPoint3)
        {
            Vector3 direction = point3.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
        if (followPoint4)
        {
            Vector3 direction = point4.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("point1"))
        {
            followPoint1 = false;
            followPoint2 = true;
            followPoint3 = false;
            followPoint4 = false;
        }
        if (other.gameObject.CompareTag("point2"))
        {
            followPoint1 = false;
            followPoint2 = false;
            followPoint3 = true;
            followPoint4 = false;
        }
        if (other.gameObject.CompareTag("point3"))
        {
            followPoint1 = false;
            followPoint2 = false;
            followPoint3 = false;
            followPoint4 = true;
        }
        if (other.gameObject.CompareTag("point4"))
        {
            followPoint1 = true;
            followPoint2 = false;
            followPoint3 = false;
            followPoint4 = false;
        }
    }

}
