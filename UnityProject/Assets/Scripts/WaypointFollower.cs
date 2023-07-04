using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointerFollo : MonoBehaviour
{

    [SerializeField] GameObject[] waypointers;
    int currentWayPointer = 0;

    [SerializeField] float speed = 5f;
 
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Vector3.Distance(transform.position, waypointers[currentWayPointer].transform.position) < 0.1f)
        {
            currentWayPointer++;
            if(currentWayPointer >= waypointers.Length)
            {
                currentWayPointer = 0;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, waypointers[currentWayPointer].transform.position, speed * Time.deltaTime);
    }
}
