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

    private void Start()
    {
        
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
    private void Update()
    {
        LevelController();
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
                break;

            case levels.lvl2:
                goLvl1.SetActive(false);
                goLvl2.SetActive(true);
                goLvl3.SetActive(false);
                goLvl4.SetActive(false);
                break;

            case levels.lvl3:
                goLvl1.SetActive(false);
                goLvl2.SetActive(false);
                goLvl3.SetActive(true);
                goLvl4.SetActive(false);
                break;

            case levels.lvl4:
                goLvl1.SetActive(false);
                goLvl2.SetActive(false);
                goLvl3.SetActive(false);
                goLvl4.SetActive(true);
                break;
        }        
    }

    public void SwitchLevel()
    {
        switch (currentlevel)
        {
            case levels.lvl1:
                currentlevel = levels.lvl2;
                break;

            case levels.lvl2:
                currentlevel = levels.lvl3;
                break;

            case levels.lvl3:
                currentlevel = levels.lvl4;
                break;
        }
    }

}
