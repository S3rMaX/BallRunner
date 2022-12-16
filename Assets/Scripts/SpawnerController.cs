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

    [SerializeField]
    void difficulties()
    {
        switch (difficulty)
        {
            case Difficulties.Easy:
                InvokeRepeating("SpawnEnemy", startDelay + 3f, spawnInterval + 3f);
                break;
            case Difficulties.Normal:
                InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
                break;
            case Difficulties.Hard:
                InvokeRepeating("SpawnEnemy", startDelay - 1f, spawnInterval - 1f);
                break;
            default:
                Debug.Log("ERROR THIS IS NOT A GAME MODE AVAILABLE");
                break;
        }
    }

    [SerializeField]
    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyIndex], transform.position, enemyPrefab[enemyIndex].transform.rotation);
    }

    public void SetActiveSpawner(bool status)
    {
        this.gameObject.SetActive(status);
        if (!status) // If Status = false then the MonoBehaviour coroutines like "InvokeRepeating" Cancel
        {
            CancelInvoke();
        }
        else
        {
            difficulties();
        }
    }
}
