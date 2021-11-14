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
    public Transform visuals;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    private void ShowLaser()
    {
        laser.Play();
    }

    public void Recoil(float duration, float magnitude)
    {
        Sequence seq = DOTween.Sequence();
        seq
            .Append(handler.DOPunchPosition((handler.position - canon.position) * magnitude, duration, 10, 8))
            .Join(handler.DOLocalRotate(new Vector3(-30, 0, 0), duration / 2).SetEase(Ease.OutSine))
            .Append(handler.DOLocalRotate(new Vector3(0, 0, 0), duration / 2).SetEase(Ease.OutSine));

    }

}
