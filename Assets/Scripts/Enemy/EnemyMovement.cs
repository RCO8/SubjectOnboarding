using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Enemy _enemy;

    Rigidbody2D rgdby2D;
    Vector2 movement = Vector2.left;
    float enemySpeed;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        rgdby2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        if(_enemy.isAlive)
            rgdby2D.velocity = enemySpeed * movement;
        else
            rgdby2D.velocity = Vector2.zero;
    }

    public void SetSpeed(float spd)
    {
        enemySpeed = spd;
    }
}
