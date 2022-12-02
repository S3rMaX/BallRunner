using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 distance;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ChasingPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Capsule"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Spawner"))
        {
            Debug.Log("Toco el Cleaner");
            
        }
    }



    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0f, -0.3f, -25f);
    }

}
