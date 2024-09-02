using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    CSVManager csvControll;

    private void Awake()
    {
        //싱글톤
        if(Instance == null)
            Instance = this;

        //csv파일 접근
        csvControll = new CSVManager();
        csvControll.LoadCSV("CSV/SampleMonster");
    }

    public Monster GetMonster(int idx)  //다른 클래스가 여기에 쉽게 접근하도록
    {
        return csvControll.GetMonsterInfo()[idx];
    }
}
