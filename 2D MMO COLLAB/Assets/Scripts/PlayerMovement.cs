using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed = 100;
    public GameObject character;
    private Rigidbody2D characterBody;
    private float ScreenWidth;
    private float ScreenHeight;
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
        ScreenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        //loop over every touch found
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                //move right
                RunCharacter(1.0f);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                //move left
                RunCharacter(-1.0f);
            }
            if (Input.GetTouch(i).position.y > ScreenHeight * 0.75f)
            {
                //move right
                CharacterVertical(0.0f, 1.0f);
            }
            if (Input.GetTouch(i).position.y < ScreenHeight * 0.25f)
            {
                //move left
                CharacterVertical(0.0f, -1.0f);
            }
            ++i;
        }
    }
    private void FixedUpdate()
    {
#if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
        CharacterVertical(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
#endif
    }

    private void RunCharacter(float horizontalInput)
    {
        // Move player along the X axis
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
    }

    private void CharacterVertical(float horizontalInput, float verticalInput)
    {
        // Move player along the X and Y axes
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, verticalInput * moveSpeed * Time.deltaTime));
    }
}
