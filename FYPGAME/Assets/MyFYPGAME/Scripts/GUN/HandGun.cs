using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    public float distance = 15f;
    Camera camera;
    public CameraShake cameraShake;

    bool isFiring;
    float shotCounter;
    public float rateOfFire = 0.4f;

    public ParticleSystem muzzleEffect;

    Animator anim;
    public AudioSource Audio;



    void Start()
    {
        camera = Camera.main;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            isFiring = true;
        else if (Input.GetButtonUp("Fire1"))
        {
            isFiring = false;
            StopAnim();
        }

        if (isFiring)
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                shotCounter = rateOfFire;
                Shoot();
            }
        }
        else
        {
            shotCounter -= Time.deltaTime;
        }       
    }

    private void Shoot()
    {
        RaycastHit hit;
        Audio.Play();
        muzzleEffect.Play();
        StartCoroutine(cameraShake.Shake(.15f, .4f));


        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            Debug.Log("Hit");
        }
        else
            Debug.Log("Not hit");

        anim.SetBool("isFiring", true);
    }

    private void StopAnim()
    {
        anim.SetBool("isFiring", false);
    }
}
