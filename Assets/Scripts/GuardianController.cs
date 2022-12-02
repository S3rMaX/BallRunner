using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianController : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    
    [SerializeField] float minimumDistance;

    [SerializeField] private int currentIndex = 0;
    [SerializeField] private bool goBack = false;
    [SerializeField] private float speedrotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 deltaVector = waypoints[currentIndex].position - transform.position;
        Vector3 direction = deltaVector.normalized;

        transform.forward = Vector3.Lerp(transform.forward,direction, speedrotation * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;

        float distance = deltaVector.magnitude;

        //Vector3.Distance(transform.position, waypoints[0].position);

        if (distance < minimumDistance)
        {
            if (currentIndex >= waypoints.Length - 1)
            {
                goBack = true;
            }
            else if (currentIndex <= 0)
            {
                goBack = false;
            }

            if (!goBack)
            {
                currentIndex++;
            }
            else currentIndex--;
        }

        
    }
}
