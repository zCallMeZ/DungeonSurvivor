using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] Camera Cam;
    Vector2 MousePosition;
    Vector2 direction;
    [SerializeField] float speed;

    // [SerializeField] AudioSource music;

    bool onPause = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
     //   music.Play();
    }


    private void FixedUpdate()

    {
        body.velocity = new Vector2(direction.x * speed * Time.fixedDeltaTime, direction.y * speed * Time.fixedDeltaTime);
        Vector2 lookDirection = MousePosition - body.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        body.rotation = angle;

    }
    void Update()
    {
        //if (Time.timeScale == 0)
        //{
        //    music.Pause();
        //}
        //if (Time.timeScale != 0)
        //{
        //    music.Play();
        //}
        
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        MousePosition = Cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
