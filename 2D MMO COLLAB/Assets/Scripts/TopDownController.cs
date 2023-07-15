using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    public Joystick joystick;

    Vector2 movement;


    // Start is called before the first frame update

    // Update is called once per frame

    void Update()
    {

        movement.x = Mathf.Round(joystick.Horizontal);
        movement.y = Mathf.Round(joystick.Vertical);


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}

