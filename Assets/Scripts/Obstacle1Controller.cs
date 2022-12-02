using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Controller : MonoBehaviour
{
    private GameObject player;
    private Collider playerCol;
    private GameObject lifeHud;
    public CameraShake cameraShake;
     


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        lifeHud = GameObject.FindGameObjectWithTag("HUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        var script = lifeHud.GetComponent<PlayerLife>();

        if (collision.collider == playerCol)
        {
            script.TakeDamage(1);
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            StartCoroutine(cameraShake.Shake(.14f,.4f));

        }
    }
}
