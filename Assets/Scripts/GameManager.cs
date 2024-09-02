using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    CSVManager csvControll;

    private void Awake()
    {
        //�̱���
        if(Instance == null)
            Instance = this;

        //csv���� ����
        csvControll = new CSVManager();
        csvControll.LoadCSV("CSV/SampleMonster");
    }

    public Monster GetMonster(int idx)  //�ٸ� Ŭ������ ���⿡ ���� �����ϵ���
    {
        return csvControll.GetMonsterInfo()[idx];
    }
}
