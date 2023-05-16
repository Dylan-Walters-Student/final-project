using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float speed = 10f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    public void SetSteerSpeed(float increaseAmount)
    {
        steerSpeed += increaseAmount;
    }

    public void SetSpeed(float increaseAmount)
    {
        speed += increaseAmount;
    }
}
