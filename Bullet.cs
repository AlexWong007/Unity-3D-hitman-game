using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public Transform Shooter;
    public int index;
    public int index2;
    public int PlayerLives;
    

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Civilian":
                Timer.Instance.time -= 30;
                Destroy(col.gameObject);
                break;
            case "Target":
                Destroy(col.gameObject);
                Points1.points += 1;
                SceneManager.LoadScene(index);
                break;
            case "Player":
                //PlayerLives--;
                //if (PlayerLives <= 0)
                //{
                //    Destroy(col.gameObject);
                //    SceneManager.LoadScene(index2);
                //}
                Destroy(col.gameObject);
                SceneManager.LoadScene(index2);
                break;
            case "Guard":
                Timer.Instance.time += 15;
                Destroy(col.gameObject);
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
