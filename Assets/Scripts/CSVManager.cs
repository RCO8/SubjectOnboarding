using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum MonsterGrade
{ Common, Rare, Magic, Legend, Hero }

public class Monster
{
    public string Name;
    public MonsterGrade Grade;
    public float Speed;
    public int MaxHealth;
    public int Health;

    public Monster(string _n, string _g, string _s, string _h)
    {
        Name = _n;
        switch(_g)
        {
            case "일반":
                Grade = MonsterGrade.Common;
                break;
            case "레어":
                Grade = MonsterGrade.Rare;
                break;
            case "매직":
                Grade = MonsterGrade.Magic;
                break;
            case "전설":
                Grade = MonsterGrade.Legend;
                break;
            case "영웅":
                Grade = MonsterGrade.Hero;
                break;
        }
        Speed = float.Parse(_s);
        Health = int.Parse(_h);
        MaxHealth = Health;
    }
}

public class CSVManager
{
    List<Monster> MonsterList = new List<Monster>();

    public void LoadCSV(string filename)
    {
        var csvData = Resources.Load<TextAsset>(filename);

        Deserial(csvData.text.TrimEnd());
    }

    public void Deserial(string data)
    {
        var rowData = data.Split('\n');

        for(int i = 1; i < rowData.Length; i++)
        {
            var datas = rowData[i].Split(",");
            MonsterList.Add(new Monster(datas[0], datas[1], datas[2], datas[3]));
        }
    }

    public List<Monster> GetMonsterInfo()   //우선 묶어서 전달
    {
        return MonsterList;
    }
}
