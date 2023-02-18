using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMobTurret : MonoBehaviour
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
        while (enemyCount < 10)
        {
            xPos = Random.Range(-12, 12);
            zPos = Random.Range(12, -12);
            Instantiate(Enemy, new Vector3(xPos, 1.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            enemyCount += 1;
        }

    }
}
