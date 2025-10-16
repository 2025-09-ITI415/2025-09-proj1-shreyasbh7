using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Ball : MonoBehaviour
{
    
    public static float bottomY = -20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 10f;
    public float speedX;
    public float speedY;
    private bool firstcollision;
    private float collisionDelay;

    void Start()
    {
        speedX = Mathf.Abs(speed); // Move right
        speedY = -Mathf.Abs(speed); // Move down

    }

    



    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Platform"))
        {
            Transform platform = other.transform;

            // Get hit position relative to paddle center
            float hitPos = transform.position.x - platform.position.x;

            // Normalize (if paddle width ~2 units)
            float platformWidth = platform.localScale.x / 2f;
            float hitRatio = hitPos / platformWidth;

            // Always go upward after hitting paddle
            speedY = Mathf.Abs(speedY);

            // Adjust horizontal speed based on hit position
            // More to the side = stronger horizontal direction
            speedX = hitRatio * speed;
        }

        // ..and if the game object we intersect has the tag 'Brick' assigned to it..
        if (other.gameObject.CompareTag("Brick"))
        {
            // Make the other game object (the pick up) inactive, to make it disappear
            other.gameObject.SetActive(false);

            //speedX = -speedX; // Change direction
            speedY = -speedY; // Change direction

            if (Random.value < 0.8f)
            {
                speedX = -speedX;
            }

            // Add one to the score variable 'count'
            //count = count + 1;

            // Run the 'SetCountText()' function (see below)
            //SetCountText();
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speedX * Time.deltaTime;
        pos.y += speedY * Time.deltaTime;

        transform.position = pos;

        // Bounce on walls
        float camHeight = Camera.main.orthographicSize * 2f;
        float camWidth = camHeight * Camera.main.aspect;

        if (pos.x > camWidth / 2f || pos.x < -camWidth / 2f)
            speedX = -speedX;

        if (pos.y > camHeight / 2f)
            speedY = -speedY;




        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }
}

