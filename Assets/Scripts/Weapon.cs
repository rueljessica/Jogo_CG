using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] private GameObject shooter;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;


    public void shoot()
    {
        if(bulletPrefab != null && firePoint != null && shooter != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            if(shooter.transform.localScale.x < 0)
            {
                bulletComponent.direction = Vector2.left;
            } else {
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}
