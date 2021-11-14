using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float fireTime = 0f;
    public int damage = 10;
    public float range = 100f;
    public ParticleSystem laser;

    public Transform canon;
    public Transform handler;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= fireTime)
        {
            Shoot();
            fireTime = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        ShowLaser();
        Recoil(.2f, .1f);
        if (Physics.Raycast(canon.position, canon.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
            Debug.DrawRay(canon.position, canon.forward * hit.distance, Color.red);
        }
    }

    private void ShowLaser()
    {
        laser.Play();
    }

    public void Recoil(float duration, float magnitude)
    {
        handler.DOPunchPosition((handler.position - canon.position) * magnitude, duration, 10, 8);
    }

}
