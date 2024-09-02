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
        //������Ʈ ���
        controll = GetComponent<EnemyMovement>();
        hp = GetComponent<EnemyHP>();

        //Ŭ����(������) ���
        enemyInfo = GameManager.Instance.GetMonster((int)Grade);
    }

    private void Start()
    {
        controll.SetSpeed(enemyInfo.Speed);
        hp.SetMaxHealth(enemyInfo.MaxHealth);
    }

    //�ǰݰ���
    public void Damaged(int hit)
    {
        int damaged = enemyInfo.Health - hit;
        enemyInfo.Health = Mathf.Max(0, damaged);
        hp.ApplyHP(enemyInfo.Health);

        isAlive = enemyInfo.Health > 0; //����ֳ�?
        if (!isAlive)
            Death();
    }
    void Death()
    {
        Debug.Log("Dead");
    }

    //Todo : ���� ���Ͱ� ������ ��������
}
