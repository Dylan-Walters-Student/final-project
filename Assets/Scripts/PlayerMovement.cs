using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float tankSteer = 250f;
    [SerializeField] float tankSpeed = 10f;
    [SerializeField] float swerveSteer = 10f;
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
        float horizontal = Input.GetAxis("Horizontal") * swerveSteer * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * swerveSpeed * Time.deltaTime;
        transform.Translate(horizontal, vertical, 0);
    }
}
