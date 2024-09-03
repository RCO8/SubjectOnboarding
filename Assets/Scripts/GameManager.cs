using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //게임에 돌아갈 시스템
    CSVManager csvControll;
    ObjectPool objPool;

    //플레이어 식별
    public PlayerAttack playerAttack;

    //몬스터 생성할 때
    Vector2 spawn = new Vector2(5, 0);

    private void Awake()
    {
        //싱글톤
        if(Instance == null)
            Instance = this;

        //csv파일 접근
        csvControll = new CSVManager();
        csvControll.LoadCSV("CSV/SampleMonster");

        //오브젝트풀 컴포넌트
        objPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        objPool.SpawnObject(0, spawn);
    }

    public Monster GetMonster(int idx)  //다른 클래스가 여기에 쉽게 접근하도록
    {
        return csvControll.GetMonsterInfo()[idx];
    }

    public void SpawnMonster()  //랜덤한 종류의 몬스터 생성
    {
        objPool.SpawnObject(Random.Range(0, 5), spawn);
    }

    public void UseArmy(string tag, Vector2 pos)
    {
        objPool.SpawnObject(tag, pos);
    }
}
