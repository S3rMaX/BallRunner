using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public enum typesPoints { Yellow, Red };

    public Inventory inventory;
    [SerializeField] private GameObject goLvl1;
    [SerializeField] private GameObject goLvl2;
    [SerializeField] private GameObject goLvl3;
    [SerializeField] private GameObject goLvl4;

    enum levels { lvl1,lvl2,lvl3,lvl4}

    [SerializeField] levels currentlevel;

    [SerializeField] GameObject[] spawnersLvl1;
    [SerializeField] GameObject[] spawnersLvl2;
    [SerializeField] GameObject[] spawnersLvl3;
    [SerializeField] GameObject[] spawnersLvl4;

    [SerializeField] private GameObject spawnPointLvl02;
    [SerializeField] private GameObject spawnPointLvl03;
    [SerializeField] private GameObject spawnPointLvl04;

    [SerializeField] private GameObject Player;

    private void Start()
    {
        LevelController();
    }

    private void Awake()
    {
        goLvl1 = GameObject.FindGameObjectWithTag("LVL1");
        goLvl2 = GameObject.FindGameObjectWithTag("LVL2");
        goLvl3 = GameObject.FindGameObjectWithTag("LVL3");
        goLvl4 = GameObject.FindGameObjectWithTag("LVL4");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LevelController()
    {
        switch (currentlevel)
        {
            case levels.lvl1:
                goLvl1.SetActive(true);
                goLvl2.SetActive(false);
                goLvl3.SetActive(false);
                goLvl4.SetActive(false);
                DisableSpawners(spawnersLvl1, true);
                DisableSpawners(spawnersLvl2, false);
                DisableSpawners(spawnersLvl3, false);
                DisableSpawners(spawnersLvl4, false);

                break;

            case levels.lvl2:
                goLvl1.SetActive(false);
                goLvl2.SetActive(true);
                goLvl3.SetActive(false);
                goLvl4.SetActive(false);
                DisableSpawners(spawnersLvl1, false);
                DisableSpawners(spawnersLvl2, true);
                DisableSpawners(spawnersLvl3, false);
                DisableSpawners(spawnersLvl4, false);
                Player.transform.position = spawnPointLvl02.transform.position;
                break;

            case levels.lvl3:
                goLvl1.SetActive(false);
                goLvl2.SetActive(false);
                goLvl3.SetActive(true);
                goLvl4.SetActive(false);
                DisableSpawners(spawnersLvl1, false);
                DisableSpawners(spawnersLvl2, false);
                DisableSpawners(spawnersLvl3, true);
                DisableSpawners(spawnersLvl4, false);
                Player.transform.position = spawnPointLvl03.transform.position;
                break;

            case levels.lvl4:
                goLvl1.SetActive(false);
                goLvl2.SetActive(false);
                goLvl3.SetActive(false);
                goLvl4.SetActive(true);
                DisableSpawners(spawnersLvl1, false);
                DisableSpawners(spawnersLvl2, false);
                DisableSpawners(spawnersLvl3, false);
                DisableSpawners(spawnersLvl4, true);
                Player.transform.position = spawnPointLvl04.transform.position;
                break;
        }        
    }

    public void SwitchLevel()
    {
        switch (currentlevel)
        {
            case levels.lvl1:
                currentlevel = levels.lvl2;
                LevelController();
                break;

            case levels.lvl2:
                currentlevel = levels.lvl3;
                LevelController();
                break;

            case levels.lvl3:
                currentlevel = levels.lvl4;
                LevelController();
                break;
        }
    }


    public void DisableSpawners(GameObject[] spawners,bool active)
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            GetSpawnerController(spawners[i]).SetActiveSpawner(active);
        }
    }

    private SpawnerController GetSpawnerController(GameObject spawner)
    {
        return spawner.GetComponent<SpawnerController>();
    }
}
