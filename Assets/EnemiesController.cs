using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public PlayerController player;
    private static EnemiesController _instance;
    private List<Enemy> enemies;


    public static EnemiesController GetInstance() => _instance;
    public bool PlayerSpoted = false;
    public float patrolTimer = 5;
    public float patrolTime = 0;

    private void Awake()
    {
        _instance = this;
        enemies = new List<Enemy>();
    }

    private void Update()
    {

        if (PlayerSpoted)
            FollowPlayer();

        else if (Time.time > patrolTime)
        {
            Patrol();
            patrolTime = Time.time + patrolTimer;
        }
    }

    public void FollowPlayer()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.agent.SetDestination(player.transform.position);
        }
    }

    public void Patrol()
    {
        foreach (Enemy enemy in enemies)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10;
            randomDirection.y = 0;
            enemy.agent.SetDestination(enemy.transform.position + randomDirection);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }
}
