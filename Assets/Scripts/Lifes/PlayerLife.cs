using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private GameObject heartsPanel;
    [SerializeField] private int lifes;
    [SerializeField] private bool dead;
    [SerializeField] private GameObject lossingHud;
    private bool startCounter = false;
    private float counter;


    

    private void Start()
    {
        Transform lifePanel = transform.Find("LifesPanel");
        int max = lifePanel.childCount;
        for (int i = 0; i < max; i++)
        {
            lifePanel.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < lifes; i++)
        {
            lifePanel.GetChild(i).gameObject.SetActive(true);
        }
        
        lossingHud.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
            dead = true;
        }

        if (dead)
        {
            Debug.Log("Your are Dead");
            lossingHud.SetActive(true);


            Time.timeScale = 0f;
            startCounter = true;
        }
        
        if (startCounter)
        {
            counter += Time.deltaTime;
        }

        if (counter >= 3f)
        {
            Application.Quit();
        }
    }
    public void TakeDamage(int dmg)
    {
        Transform lifePanel = transform.Find("LifesPanel");
        if (lifes >= 1 && !dead)
        {
            int actives = 0;
            lifes -= dmg;
            int max = lifePanel.childCount;
            for (int i = 0; i < max; i++)
            {
                if (lifePanel.GetChild(i).gameObject.activeSelf)
                {
                    actives += 1;
                }
            }
            int containernumber = 0;
            for (int i = 0; i < max; i++)
            {
                if (containernumber == actives - 1)
                {
                    lifePanel.GetChild(containernumber).gameObject.SetActive(false);
                    actives -= 1;
                }
                else
                {
                    containernumber += 1;
                }
            }
        }
        else
        {
            dead = true;

        }
    }
    public void HealLife(int healValue)
    {
        Transform lifePanel = transform.Find("LifesPanel");
        
        if (lifes >= 1)
        {
            lifes += healValue;

            if (lifes >= 4)
            {
                lifes = 4;
            }
            
            for (int i = 0; i < healValue; i++)
            {
                int max = lifePanel.childCount;
                int actives = 0;
                for (i = 0; i < max; i++)
                {
                    if (lifePanel.GetChild(i).gameObject.activeSelf)
                    {
                        actives += 1;
                    }
                }

                lifePanel.GetChild(actives).gameObject.SetActive(true);
            }
        }
    }
}
