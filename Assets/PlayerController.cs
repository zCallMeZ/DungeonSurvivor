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

    private Vector2 rightStickInput;

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

        //if (rightStickInput.magnitude > 0f)
        //{
        //    Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.up * rightStickInput.y;
        //    Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.forward);

        //    body.SetRotation(playerRotation);
        //}
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
        //RightStick();
    }
    void RightStick()
    {
        rightStickInput = new Vector2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"));
    }
}
