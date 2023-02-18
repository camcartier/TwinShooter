using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMob : GameManager
{
    public int enemyCount = 0;
    public int xPos;
    public int zPos;
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine(MobSpawn());
    }

    IEnumerator MobSpawn()
    {
        while (enemyCount < 1)
        {
            xPos = Random.Range(1, 3);
            zPos = Random.Range(1, 3);
            Instantiate(Enemy, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            enemyCount +=1;
        }

    }
}
