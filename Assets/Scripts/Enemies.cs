using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 5f;
    Rigidbody2D rb;
    Vector2 movement;

    void Start() 
    {
        rb = this.GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        ChasePlayer();
    }

    void FixedUpdate() {
        Move(movement);
    }

    void ChasePlayer()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
