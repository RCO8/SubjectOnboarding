using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{
    //Todo : 1초간 공격

    private float waitTime = 1f;
    private WaitForSeconds waitCoroutine = new WaitForSeconds(1f);

    Vector2 playerPos;
    Vector2 maxPos;
    Collider2D findEnemies;

    private void Start()
    {
        //overlap 감지
        playerPos = transform.position;
        maxPos = Vector2.one * 5;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return waitCoroutine;

            //1초간 대기하다 공격
            Debug.Log("공격");
            findEnemies = Physics2D.OverlapBox(playerPos, maxPos, 0f);
            Enemy e = findEnemies.GetComponent<Enemy>();
            e.Damaged(100);
        }
    }
}
