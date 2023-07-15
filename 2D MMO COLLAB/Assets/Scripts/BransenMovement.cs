using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BransenMovement : MonoBehaviour
{
    public float speed;

    public Animator animator;
    //get input from player
    //apply movement to sprite
    public Joystick joystick;

    private Vector3 direction;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        horizontal = joystick.Horizontal * speed * Time.deltaTime;
        vertical = joystick.Vertical * speed * Time.deltaTime;

        direction = new Vector3(horizontal, vertical);

        direction.Normalize();
        AnimateMovement(direction);

       
    }

    private void FixedUpdate()
    {
        this.transform.position += direction.normalized * speed * Time.deltaTime;
    }
    private void AnimateMovement(Vector3 direction)
    {
        if(animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
           
        }
    }
}
