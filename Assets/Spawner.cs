using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject buddy;
    [SerializeField] private Queue<GameObject> spawn = new Queue<GameObject>();
    [SerializeField] private int spawnCount = 1;

    [SerializeField] private Queue<Transform> spawnTransform = new Queue<Transform>();


    
    // Start is called before the first frame update
    void Start()
    {

        /*
        for(int i = 0; i < spawnCount; i++)
        {
            Transform t;
            t = transform;
            t.position -= new Vector3(0, 0, i / 2);
            spawnTransform.Enqueue(t);


        }

        for (int i = 0; i < spawnCount; i++) 
        {

            GameObject gb = Instantiate(buddy, spawnTransform.Peek().position, Quaternion.identity);
            spawnTransform.Dequeue();
        }
        */
        InvokeRepeating("Spawn", 2f, 2f);


        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            GameObject gb  = Instantiate(buddy, transform.position, Quaternion.identity);
        }
        */

        //GameObject gb = Instantiate(buddy, transform.position, Quaternion.identity);


    }

    private void FixedUpdate()
    {
        //GameObject gb = Instantiate(buddy, transform.position, Quaternion.identity);
    }

    private void Spawn()
    {
        GameObject gb = Instantiate(buddy, transform.position, Quaternion.identity);
    }
}
