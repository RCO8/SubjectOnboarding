using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{
    //Todo : 1�ʰ� ����

    private float waitTime = 1f;
    private WaitForSeconds waitCoroutine = new WaitForSeconds(1f);

    Vector2 playerPos;
    Vector2 maxPos;
    Collider2D findEnemies;

    private void Start()
    {
        //overlap ����
        playerPos = transform.position;
        maxPos = Vector2.one * 5;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return waitCoroutine;

            //1�ʰ� ����ϴ� ����
            Debug.Log("����");
            findEnemies = Physics2D.OverlapBox(playerPos, maxPos, 0f);
            Enemy e = findEnemies.GetComponent<Enemy>();
            e.Damaged(100);
        }
    }
}
