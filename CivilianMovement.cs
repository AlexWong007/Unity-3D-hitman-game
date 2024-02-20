using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
   

    Vector2 movement;
   


   
    void Update()
    {
        if (movement.x > 0) transform.localScale = new Vector3(10, 10, 10);
        if (movement.x < 0) transform.localScale = new Vector3(-10, 10, 10);


        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        animator.SetBool("Horizontal", ((Mathf.Abs(movement.x) > 0.1f) ? true : false));
        animator.SetBool("Up", ((movement.y > 0.1f) ? true : false));
        animator.SetBool("Down", ((movement.y < 0.1f) ? true : false));


    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

       
    }


}
