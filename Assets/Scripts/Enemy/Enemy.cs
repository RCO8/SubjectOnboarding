using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyMovement controll;
    EnemyHP hp;

    public MonsterGrade Grade;
    private Monster enemyInfo;

    public bool isAlive { get; private set; } = true;

    private void Awake()
    {
        //컴포넌트 등록
        controll = GetComponent<EnemyMovement>();
        hp = GetComponent<EnemyHP>();

        //클래스(데이터) 등록
        enemyInfo = GameManager.Instance.GetMonster((int)Grade);
    }

    private void Start()
    {
        controll.SetSpeed(enemyInfo.Speed);
        hp.SetMaxHealth(enemyInfo.MaxHealth);

    }

    //피격관련
    public void Damaged(int hit)
    {
        int damaged = enemyInfo.Health - hit;
        enemyInfo.Health = Mathf.Max(0, damaged);
        hp.ApplyHP(enemyInfo.Health);

        isAlive = enemyInfo.Health > 0; //살아있나?
        if (!isAlive)
            StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        //죽으면 재생성을 위해 초기
        enemyInfo.Health = enemyInfo.MaxHealth;
        gameObject.SetActive(false);
        GameManager.Instance.SpawnMonster();
    }
}
