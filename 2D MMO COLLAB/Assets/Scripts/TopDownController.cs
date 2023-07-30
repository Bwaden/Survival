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

    [SerializeField]
    public float speed;

    // Start is called before the first frame update

    // Update is called once per frame

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    // Normalize the movement vector
        movement.Normalize();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }

    }

    void FixedUpdate()
    {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    }
