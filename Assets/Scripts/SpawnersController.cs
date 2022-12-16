using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject selected;

    [SerializeField] private bool ahre;



//    // Start is called before the first frame update
//    void Start()
//    {
//        //DisableSpawners();        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (ahre)
//        {
//           // ActivateAllSpawnersOfOneLvl();

//        }
//    }

//    private void DisableSpawners()
//    {
//        for (int i = 0; i < spawners.Length; i++)
//        {
//            //spawners[i].SetActive(false);
//            Debug.Log("Spawners length" + spawners.Length);
//            Debug.Log("Spawners Set active" + spawners[i]);
//            GetSpawnerController(spawners[i]).SetActiveSpawner(false);

//        }
//    }

//    private void ActivateOne()
//    {
//        int spawnersIndex = Random.Range(0, spawners.Length);
//        GetSpawnerController(spawners[spawnersIndex]).SetActiveSpawner(true);
//        setSelected(spawners[spawnersIndex].transform);
//        //spawners[spawnersIndex].SetActive(true);
//    }

//    private void ActivateAllSpawnersOfOneLvl()
//    {

//        for (int i = 0; i < spawners.Length; i++)
//        {

//            Debug.Log("Spawners Set active" + spawners[i]);
//            GetSpawnerController(spawners[i]).SetActiveSpawner(true);

//        }

//    }

//    private SpawnerController GetSpawnerController(GameObject spawner)
//    {
//        return spawner.GetComponent<SpawnerController>();
//    }

//    private void setSelected(Transform target)
//    {
//        selected.transform.position = new Vector3(target.position.x, target.position.y + 1.8f, target.position.z);
//    }
}
