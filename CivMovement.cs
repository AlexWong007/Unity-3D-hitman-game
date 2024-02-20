using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    private int WalkDirection;
    [SerializeField] Animator animator;
    public static CivMovement instance;
    Vector2 movement;

    // Use this for initialization
    void Start()
    {
        instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            waitCounter -= Time.deltaTime;


            switch (WalkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;

            }
            if (waitCounter <= 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

            if (movement.x > 0) transform.localScale = new Vector3(150, 150, 150);
            if (movement.x < 0) transform.localScale = new Vector3(-150, 150, 150);
            //movement.x = Input.GetAxisRaw("Horizontal");
            //movement.y = Input.GetAxisRaw("Vertical");

            animator.SetBool("Horizontal", ((Mathf.Abs(movement.x) > 0.1f) ? true : false));
            animator.SetBool("Up", ((movement.y > 0.1f) ? true : false));
            animator.SetBool("Down", ((movement.y < 0.1f) ? true : false));
        }

        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        waitCounter = walkTime;

    }
}