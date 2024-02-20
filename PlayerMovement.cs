using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    public static PlayerMovement instance;

    public Vector3 getPosition()
    {
        return transform.position;
    }

    Vector2 movement;
    

    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        if (movement.x > 0) transform.localScale = new Vector3(150, 150, 150);
        if (movement.x < 0) transform.localScale = new Vector3(-150, 150, 150);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        bool left_click = Input.GetMouseButtonDown(0);

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("Shoot", left_click ? true : false);
        animator.SetBool("Horizontal",((Mathf.Abs(movement.x) > 0.1f) ?true : false));
        animator.SetBool("Up",((movement.y > 0.1f) ?true : false));
        animator.SetBool("Down",((movement.y < 0.1f && movement.y != 0) ?true : false));
        animator.SetBool("Idle", ((movement.y == 0 && movement.x == 0) ? true : false));
        
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //bool left_click = Input.GetMouseButtonDown(0);
        //animator.SetBool("Shoot", left_click ? true : false);
    }


}
