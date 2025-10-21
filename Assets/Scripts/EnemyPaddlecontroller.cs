using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddlecontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;

    public Vector2 limits = new Vector2(-2.90f, 2.90f);

    private GameObject ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); //Encontra o objeto da bola na cena
    }

    private void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y); //limita a posição Y
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); // Move gradualmente para a posição Y da bola
        }
    }
}
