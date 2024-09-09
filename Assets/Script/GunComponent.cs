using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 10f;
    private float chargeTime = 0f;

   
    void Start()
    {
 
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //hint 1
            chargeTime = 0f;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            // Spawn bullet when Fire1 is released
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            bulletComp.bulletSpeed *= chargeTime;
        }
        if(Input.GetButton("Fire1")) //all of the frames where the button is being pressed down
        {
            chargeTime += Time.deltaTime * chargeSpeed;
            chargeTime = Mathf.Clamp(chargeTime, 0, 3);
        }
    }
}

