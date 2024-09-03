using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{
    //Todo : 1�ʰ� ����

    public float AttackSpeed = 1f;
    private WaitForSeconds waitCoroutine;

    Vector2 playerPos;
    Vector2 maxPos;
    Collider2D findEnemies;

    ObjectPool useForArrow; //ȭ���� ����� ��

    private void Start()
    {
        waitCoroutine = new WaitForSeconds(AttackSpeed);

        //overlap ����
        playerPos = transform.position;
        maxPos = Vector2.one * 10;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return waitCoroutine;

            //Todo : �׷��� �ϴ°� ���� �÷��̾ ȭ��� ���͸� ���� ����
            GameManager.Instance.UseArmy("Army", transform.position);

            //1�ʰ� ����ϴ� ����
            /*findEnemies = Physics2D.OverlapBox(playerPos, maxPos, 0f);
            Enemy e = findEnemies.GetComponent<Enemy>();
            e.Damaged(100);*/
        }
    }
}
