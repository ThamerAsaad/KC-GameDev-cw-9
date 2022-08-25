using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform GroundPos;
    public float speed;
    public LayerMask GroundLayer;

    Rigidbody2D rb;
    public float rad;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        rb.velocity = new Vector2(speed, 0f);
        bool isGrounded = Physics2D.OverlapCircle(GroundPos.position, rad , GroundLayer);
        if (!isGrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
