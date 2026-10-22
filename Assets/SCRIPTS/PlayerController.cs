using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 
    public float limitTop;// Top Limit of de paddle´s movement
    public float limitBottom;//Bottom Limit of de paddle´s movement
    public bool useArrowkey = false;

    void Update()
    {
        MovePaddle();
    }
    void MovePaddle()
    {
        this.gameObject.transform.position = new Vector3(transform.position.x, ConstraintPaddle(), transform.position.z);
    }
    float ConstraintPaddle()
    {
        float newY = this.gameObject.transform.position.y + (PaddleDirection() * moveSpeed * Time.deltaTime); 
        if (newY > limitTop) 
        {
            newY = limitTop;
        }
        if (newY < limitBottom) 
        {
            newY = limitBottom;
        }
        return newY;
    }
    float PaddleDirection()
    {
        float direction = 0f;
        if (useArrowkey == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction = 1f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction = -1f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                direction = 1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction = -1f;
            }
        }
        return direction;
    }
}