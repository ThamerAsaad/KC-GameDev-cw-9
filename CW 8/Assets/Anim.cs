using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    Animator anim;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(canJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            anim.SetBool("Jump", true);

            anim.SetBool("Run", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor" && (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.A)))
        {
            canJump = true;
            anim.SetBool("Jump" , false);

            anim.SetBool("Run", true);
        }
        else if (collision.gameObject.tag == "Floor" && Input.anyKey == false)
        {
            canJump = true;
            anim.SetBool("Jump", false);

            anim.SetBool("Run", false);
        }
    }
}
