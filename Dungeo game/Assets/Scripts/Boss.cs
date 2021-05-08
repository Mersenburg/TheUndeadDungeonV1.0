using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static Boss IBoss;
    public float Timer = 10;
    public GameObject EnemyPrefab;
    public Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        IBoss = this;
    }

    // Update is called once per frame
    public void SpawnEnemy()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            GameObject obj = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
            Timer = 10;
        }
    }
}
