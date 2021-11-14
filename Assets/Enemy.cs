using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private int _hp = 50;
    public NavMeshAgent agent;
    private EnemiesController e_controller;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        e_controller = EnemiesController.GetInstance();
        e_controller.AddEnemy(this);
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        
        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        e_controller.RemoveEnemy(this);
        Destroy(gameObject);
    }
}
