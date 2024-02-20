using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardmovement : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float bulletForce;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] float Cooldown;
    [SerializeField] float Reactiontime;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float Counter;


    Vector2 movement;




    void Update()
    {
        if (movement.x > 0) transform.localScale = new Vector3(10, 10, 10);
        if (movement.x < 0) transform.localScale = new Vector3(-10, 10, 10);


        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        Counter -= Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerMovement.instance.getPosition() - transform.position, Mathf.Infinity, layerMask, -Mathf.Infinity, Mathf.Infinity);
        //print("test");
        //if (hit != null)
        //{
        //    print(hit.collider.gameObject.name);
        //}
        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            if(Counter < 0)
            {
                Counter = Cooldown;
                Shoot();
            }


            //print(hit.transform.name);
        } else if(Counter < Reactiontime)
        {
            Counter = Reactiontime;
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);


    }

    void Shoot()
    {
        //print("Shoot");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.Normalize(PlayerMovement.instance.getPosition() - transform.position) * bulletForce, ForceMode2D.Impulse);
        bullet.transform.GetComponent<Bullet>().Shooter = transform;
    }

}
