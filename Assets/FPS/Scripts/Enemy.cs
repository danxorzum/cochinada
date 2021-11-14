using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    private int _hp = 50;
    public NavMeshAgent agent;
    private EnemiesController e_controller;
    public Transform visuals;
    public Collider col;
    
    Collider[] colliders;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        e_controller = EnemiesController.GetInstance();
        e_controller.AddEnemy(this);
        col = GetComponent<Collider>();
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;

        visuals.DOComplete();
        visuals.DOShakeScale(.2f, .5f, 40, 90);

        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        col.enabled = false;
        e_controller.RemoveEnemy(this);

        visuals.DOComplete();

        Sequence sq = DOTween.Sequence();

        sq
            .Append(visuals.DOJump(transform.position, 1f, 1, .3f).SetEase(Ease.InSine))
            .Join(visuals.DOShakeRotation(1, 150f, 10, 90))
            .OnComplete(() => Destroy(gameObject));
    }
}
