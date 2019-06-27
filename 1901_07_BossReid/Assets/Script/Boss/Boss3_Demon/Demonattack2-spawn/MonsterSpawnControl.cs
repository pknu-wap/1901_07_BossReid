using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnControl : MonoBehaviour
{
    public Transform[] spawnPoints; // 스폰될 위치
    public GameObject[] monsters; // 스폰 대상
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 1f, 2f); // 몬스터 소환 주기
    }

    void Update()
    {
        var reference = GameObject.Find("Demon").GetComponent<DemonHP>();
        if (reference.HP == 0)
        {
            spawnAllowed = false;
        }
    }

    void SpawnAMonster()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);

            GameObject.Find("Boss_3_Spawned").GetComponent<AudioSource>().Play();
        }
    }
}