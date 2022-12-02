using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 6f;
    private GameObject player;
    [SerializeField] private float lifetime;
    [SerializeField] private float speedToLook = .5f;
    [SerializeField] private float distanceEnemy = 3;

    [SerializeField] private Rigidbody rbEnemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rbEnemy = GetComponent<Rigidbody>();
    }


    void Update()
    {
        

        Vector3 playerDirection = GetPlayerDirection();
        rbEnemy.AddForce(playerDirection * Time.deltaTime);
        if (transform.position.y <= -125f)
        {
            Destroy(gameObject);
        }
    }

    
    private void MoveEnemy(Vector3 direction)
    {
        //transform.Translate(speedEnemy * direction * Time.deltaTime);
        transform.position += speedEnemy * direction * Time.deltaTime;
    }

    private void MoveTowards()
    {
        Vector3 lookAtVector = player.transform.position - transform.position;
        Vector3 direction = lookAtVector.normalized;
        if (lookAtVector.magnitude > distanceEnemy)
        {
            transform.position += speedEnemy * direction * Time.deltaTime;
        }
    }

    private void LookAtLerp(GameObject lookObject)
    {
        Vector3 direction = (lookObject.transform.position - transform.position).normalized;
        Quaternion newQuaternion = Quaternion.LookRotation(direction);
        //transform.rotation = newQuaternion;
        transform.rotation = Quaternion.Lerp(transform.rotation, newQuaternion, speedToLook * Time.deltaTime);
    }

    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }
}
