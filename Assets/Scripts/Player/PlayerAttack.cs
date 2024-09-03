using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{
    //Todo : 1초간 공격

    public float AttackSpeed = 1f;
    private WaitForSeconds waitCoroutine;

    Vector2 playerPos;
    Vector2 maxPos;
    Collider2D findEnemies;

    ObjectPool useForArrow; //화살을 사용할 때

    private void Start()
    {
        waitCoroutine = new WaitForSeconds(AttackSpeed);

        //overlap 감지
        playerPos = transform.position;
        maxPos = Vector2.one * 10;

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return waitCoroutine;

            //Todo : 그렇게 하는것 보다 플레이어가 화살로 몬스터를 직접 공격
            GameManager.Instance.UseArmy("Army", transform.position);

            //1초간 대기하다 공격
            /*findEnemies = Physics2D.OverlapBox(playerPos, maxPos, 0f);
            Enemy e = findEnemies.GetComponent<Enemy>();
            e.Damaged(100);*/
        }
    }
}
