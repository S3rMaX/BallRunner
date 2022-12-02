using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class forceController : MonoBehaviour
{
    [SerializeField] private float pushForce = 30f;
    [SerializeField] private float timeToLive = 1.5f;
    private GameObject player;
    private Rigidbody rb;
    private Collider playerCol;
    private Vector3 pushDirection;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCol = player.GetComponent<Collider>();
        Destroy(gameObject, timeToLive);
        rb = GetComponent<Rigidbody>();
        pushDirection = rb.velocity.normalized;
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            if (otherRB != playerCol)
            {
                otherRB.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
        

    }
}
