using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMobPirangna : MonoBehaviour
{
    public int enemyCount = 0;
    public int xPos;
    public int zPos;
    public GameObject Enemy;
    void Start()
    {
        StartCoroutine(MobSpawn(GameManager.lvl1PirangnaNumber));
    }

    IEnumerator MobSpawn(int numberToSpawn)
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(1, 3);
            zPos = Random.Range(1, 3);
            Instantiate(Enemy, new Vector3(xPos, 0.5f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(4);
            enemyCount +=1;
        }

    }
}
