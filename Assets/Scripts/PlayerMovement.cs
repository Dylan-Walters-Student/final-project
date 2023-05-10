using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float tankSteer = 250f;
    [SerializeField] float tankSpeed = 10f;
    [SerializeField] float swerveSpeed = 10f;
    [SerializeField] bool driveMode;

    void Update()
    {
        if (driveMode)
        {
            SwerveDrive();
        }
        else
        {
            TankDrive();
        }
    }

    void TankDrive()
    {
        float steerAmount = Input.GetAxis("Horizontal") * tankSteer * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * tankSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void SwerveDrive()
    {
        LookAtMouse();
        float horizontal = Input.GetAxis("Horizontal") * swerveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * swerveSpeed * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);
    }

    void LookAtMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mousePosition - new Vector2(transform.position.x, transform.position.y);
    }
}
