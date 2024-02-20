using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Camera Cam;

    //public AudioClip fireclip;
    //public AudioSource audioSource;

    public float bulletForce = 2f;
    
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    //private void InstantiateAudio(AudioClip clip)
    //{
    //    audioSource = gameObject.AddComponent<AudioSource>();
    //    audioSource.clip = clip;
    //}

    //public void playSound()
    //{
    //    if (audioSource.isPlaying)
    //    {
    //        audioSource.Stop();
    //        audioSource.Play();
    //    }
    //}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
            //audioSource.PlayOneShot(fireclip, 0.7F);
            
        }

    }

    void Shoot()
    {
        Vector2 mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        rb.AddForce(Vector3.Normalize(mousePos-rb.position) * bulletForce, ForceMode2D.Impulse);
        bullet.transform.GetComponent<Bullet>().Shooter = transform;
        
    }
}
