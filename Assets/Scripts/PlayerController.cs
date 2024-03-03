using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 direction;
    public float forwardSpeed;
    public static int shapeSmashed;

    //Laneposition; -1 for left, 0 for center, 1 for right
    private int lanePosition = 0;

    //Distance betweeen lanes
    private float laneDistance = 3f;

    
    void Start()
    {
        shapeSmashed = 0;
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        //switch lane to right using key D and RightArrow
        if (Input.GetKeyDown(KeyCode.D))
        {
            lanePosition++;
            if (lanePosition == 2)
                lanePosition = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lanePosition++;
            if (lanePosition == 2)
                lanePosition = 1;
        }

        //switch lane to right using key A and LeftArrow
        if (Input.GetKeyDown(KeyCode.A))
        {
            lanePosition--;
            if (lanePosition == -2)
                lanePosition = -1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lanePosition--;
            if (lanePosition == -2)
                lanePosition = -1;
        }

        //Checking player position in the future
        Vector3 playerPosition = transform.position;
        playerPosition.x = lanePosition * laneDistance;
        transform.position = playerPosition;
    }

    }
