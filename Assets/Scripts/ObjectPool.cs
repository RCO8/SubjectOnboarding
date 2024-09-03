using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class MonsterPool
    {
        public MonsterGrade grade;
        public GameObject prefab;
        public int size;
    }

    [System.Serializable]
    public class ArmyPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //Monster
    public List<MonsterPool> MonsterPools;
    public Dictionary<MonsterGrade, Queue<GameObject>> MonsterPoolDict;

    //Army
    public List<ArmyPool> ArmyPools;
    public Dictionary<string, Queue<GameObject>> ArmyPoolDict;

    private void Awake()
    {
        //Monster
        MonsterPoolDict = new Dictionary<MonsterGrade, Queue<GameObject>>();
        foreach(var pool in MonsterPools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            MonsterPoolDict.Add(pool.grade, objPool);
        }

        //Army
        ArmyPoolDict = new Dictionary<string, Queue<GameObject>>();
        foreach(var pool in ArmyPools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for(int i = 0;i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            ArmyPoolDict.Add(pool.tag, objPool);
        }
    }

    public GameObject SpawnObject(int tag, Vector2 pos)
    {
        MonsterGrade thisGrade = (MonsterGrade)tag;
        if (!MonsterPoolDict.ContainsKey(thisGrade))
            return null;

        GameObject obj = MonsterPoolDict[thisGrade].Dequeue();
        obj.transform.position = pos;
        MonsterPoolDict[thisGrade].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }

    public GameObject SpawnObject(string tag, Vector2 pos)
    {
        if (!ArmyPoolDict.ContainsKey(tag))
            return null;

        GameObject obj = ArmyPoolDict[tag].Dequeue();
        obj.transform.position = pos;
        ArmyPoolDict[tag].Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}