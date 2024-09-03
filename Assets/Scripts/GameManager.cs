using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //���ӿ� ���ư� �ý���
    CSVManager csvControll;
    ObjectPool objPool;

    //�÷��̾� �ĺ�
    public PlayerAttack playerAttack;

    //���� ������ ��
    Vector2 spawn = new Vector2(5, 0);

    private void Awake()
    {
        //�̱���
        if(Instance == null)
            Instance = this;

        //csv���� ����
        csvControll = new CSVManager();
        csvControll.LoadCSV("CSV/SampleMonster");

        //������ƮǮ ������Ʈ
        objPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        objPool.SpawnObject(0, spawn);
    }

    public Monster GetMonster(int idx)  //�ٸ� Ŭ������ ���⿡ ���� �����ϵ���
    {
        return csvControll.GetMonsterInfo()[idx];
    }

    public void SpawnMonster()  //������ ������ ���� ����
    {
        objPool.SpawnObject(Random.Range(0, 5), spawn);
    }

    public void UseArmy(string tag, Vector2 pos)
    {
        objPool.SpawnObject(tag, pos);
    }
}
