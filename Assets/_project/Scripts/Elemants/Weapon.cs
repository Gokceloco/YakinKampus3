using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform shootPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = shootPoint.position;
        newBullet.transform.LookAt(newBullet.transform.position + shootPoint.forward);
    }
}
