using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

//TODO Mettre des commentaires + Enlever les using non utilisés + Ranger le code

public class ZombieTankController : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;
    [SerializeField] private Transform point4;

    private bool followPoint1 = true;
    private bool followPoint2 = false;
    private bool followPoint3 = false;
    private bool followPoint4 = false;

    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float speed = 3.0f;
    private Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (followPoint1)
        {
            Movement();
            direction = point1.position - transform.position;
            Movement();
        }
        if (followPoint2)
        {
            Movement();
            direction = point2.position - transform.position;
            Movement();
        }
        if (followPoint3)
        {
            Movement();
            direction = point3.position - transform.position;
            Movement();
        }
        if (followPoint4)
        {
            Movement();
            direction = point4.position - transform.position;
            Movement();
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void Movement()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
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
