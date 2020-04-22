using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxController : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 rightStickInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        RightStick();
    }

    void RightStick()
    {
        rightStickInput = new Vector2(Input.GetAxis("RHorizontal"), Input.GetAxis("RVertical"));
    }

    private void FixedUpdate()
    {
        if (rightStickInput.magnitude > 0f)
        {
            Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.up * rightStickInput.y;
            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.forward);

            rb.SetRotation(playerRotation);
        }
    }
}
