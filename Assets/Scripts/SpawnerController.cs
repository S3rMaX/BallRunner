using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefab;
    [SerializeField] public float startDelay = 2;
    [SerializeField] public float spawnInterval = 1.5f;
    

    [SerializeField] enum Difficulties { Easy = 1, Normal , Hard}
    [SerializeField] private Difficulties difficulty;

    [SerializeField] private bool isActive;
    void Start()
    {
        
        switch (difficulty)
        {
            case Difficulties.Easy:
                //Debug.Log("EASY MODE");
                InvokeRepeating("SpawnEnemy", startDelay + 3f, spawnInterval + 3f);
                break;
            case Difficulties.Normal:
                //Debug.Log("NORMAL MODE");
                InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
                break;
            case Difficulties.Hard:
                //Debug.Log("HARD MODE");
                InvokeRepeating("SpawnEnemy", startDelay - 1f, spawnInterval -1f);
                break;
            default:
                //Debug.Log("ERROR THIS IS NOT A GAME MODE AVAILABLE");
                break;
        }
    }
    
    [SerializeField]
    void Update()
    {
        
    }

    [SerializeField]
    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyIndex], transform.position, enemyPrefab[enemyIndex].transform.rotation);
    }

    public void SetActiveSpawner(bool status)
    {
        isActive = status;
    }
}
