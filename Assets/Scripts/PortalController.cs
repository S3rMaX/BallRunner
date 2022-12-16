using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private GameObject[] winningHud;

    // Start is called before the first frame update
    void Start()
    {
        if (winningHud[0])
        {
            winningHud[0].SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwitchLevel();
        }
    }

    void SwitchLevel()
    { 
        if (this.gameObject.CompareTag("FinalPortal1"))
        {
            GameManager.instance.SwitchLevel();
            FindObjectOfType<AudioManager>().Play("PortalJump");
        }

        if (this.gameObject.CompareTag("FinalPortal2"))
        {
            GameManager.instance.SwitchLevel();
            FindObjectOfType<AudioManager>().Play("PortalJump");
        }

        if (this.gameObject.CompareTag("FinalPortal3"))
        {
            GameManager.instance.SwitchLevel();
            FindObjectOfType<AudioManager>().Play("PortalJump");
        }

        if (this.gameObject.CompareTag("FinalPortal4"))
        {
            winningHud[0].SetActive(true);
            FindObjectOfType<AudioManager>().Play("PortalJump");
            FindObjectOfType<AudioManager>().Play("Winning");
            Time.timeScale = 0f;
        }
    }
}
