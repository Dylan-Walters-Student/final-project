using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemies : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI redScoreText;
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 5f;
    float nextScoreTime = 1;
    Rigidbody2D rb;
    Vector2 movement;

    void Start() 
    {
        rb = this.GetComponent<Rigidbody2D>();    
        redScoreText.text = $"{StaticHelper.enemyScore}";
        StaticHelper.enemyScore = 0;
    }
    void Update()
    {
        if (Time.time >= nextScoreTime)
        {
            Score();
            nextScoreTime = Time.time + 1f;
        }
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

    void Score()
    {
        StaticHelper.enemyScore++;
        redScoreText.text = $"{StaticHelper.enemyScore}";
    }
}
