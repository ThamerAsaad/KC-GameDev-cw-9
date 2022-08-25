using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool FaceRight = true;

    public GameObject bullet;
    GameObject bulletClone;
    public Transform LeftSpawm;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }
    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && FaceRight == false)
        {
            sprite.flipX = false;
            FaceRight = true;

        }
        if (Input.GetKeyDown(KeyCode.A) && FaceRight == true)
        {
            sprite.flipX = true;
            FaceRight = false;

        }
    }
    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && FaceRight)
        {
            bulletClone = Instantiate(bullet , transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        }
        else if(Input.GetMouseButtonDown(0) && !FaceRight)
        {
            bulletClone = Instantiate(bullet, LeftSpawm.position, LeftSpawm.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
        }
        Destroy(bulletClone , 1.5f);
    }
    
}

