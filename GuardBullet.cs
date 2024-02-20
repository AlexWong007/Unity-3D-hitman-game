using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardBullet : MonoBehaviour
{
    public Transform Shooter;
    public int index;
    public int index2;
    


    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Civilian":
                
                break;
            case "Target":
                
                break;
            case "Player":
                Destroy(col.gameObject);
                SceneManager.LoadScene(index2);
                break;
            case "Guard":
                
                break;

        }
        if (col.gameObject.transform != Shooter)
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), Shooter.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
