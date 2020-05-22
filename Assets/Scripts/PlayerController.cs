using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    [SerializeField] float speed = 5f; 

    private void Start() //TODO(@Bryan) Why using the modifer private here but not for a variable? Be consistent!
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime); //TODO(@Bryan) Why using a rigidbody if it's for moving it by displacement?
            
        //TODO(@Bryan) This is on the "visual layer" this should be in the Update funciton.
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90; //TODO(@Bryan) Be specific, 90 is used with float, you must also use a float.
        rb.rotation = angle; //TODO(@Bryan) Don't apply rotation to rigidbody, apply it to a transform.
    }
}
