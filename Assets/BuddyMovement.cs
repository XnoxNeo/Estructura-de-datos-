using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyMovement : MonoBehaviour
{

    [SerializeField] private Transform queuePlace;
    [SerializeField] private MallStand mallStand;
    [SerializeField] private Transform productPlacement;

    [SerializeField] private float speed = 1;

    [SerializeField] private bool checkAvailable;
    [SerializeField] private bool checkComplete;
    [SerializeField] private bool checkCancelled;



    [SerializeField] private GameObject[] stands;
    [SerializeField] private int standsCount;

    // para la salida
    [SerializeField] private Transform finishLine;

    void Start()
    {



       ;

        //queuePlace = GameObject.FindWithTag("QueuePlace").transform;

        //mallStand = GameObject.FindWithTag("StandPlace").GetComponent<MallStand>();

        finishLine = GameObject.FindWithTag("Finish").GetComponent<Transform>();


        stands = GameObject.FindGameObjectsWithTag("Stand");
        

        int standChosen = Random.Range(0, stands.Length);


        queuePlace = stands[standChosen].transform.Find("Queue Place");
        //queuePlace = stands[standChosen].GetComponentInChildren<Transform>();
        mallStand = stands[standChosen].GetComponentInChildren<MallStand>();
        


        checkAvailable = true;
        checkComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        standsCount = stands.Length;

        
        if(Input.GetKeyUp(KeyCode.M))
        {
            checkAvailable = true;
        }
        //transform.position = Vector3.MoveTowards(transform.position, queuePlace.position, speed * Time.deltaTime);


        if (checkAvailable)
        {
            transform.position = Vector3.MoveTowards(transform.position, queuePlace.position, speed * Time.deltaTime);
        }


        if(checkComplete)
        {
            StartCoroutine(checkOut());
        }
       

        if(checkCancelled)
        {
            StartCoroutine(checkOut());
        }




        

        
    }

    
    private void ObjTryDequeue()
    {
        



        if (mallStand.mallObjects.TryPop(out GameObject dequeuedObject))
        {

           


            Debug.Log("Dequeued object: " + dequeuedObject.name);
            checkAvailable = false;

            dequeuedObject.transform.SetParent(productPlacement,false);
            checkComplete = true;
            //mallStand.standCounter =0;
            
            
        }
        else
        {
            checkComplete = false;
            checkCancelled = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("QueuePlace"))
        {
            ObjTryDequeue();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QueuePlace") && mallStand.mallObjects.Count > 0)
        {
            ObjTryDequeue();
        }
        else if (other.CompareTag("QueuePlace"))
        {
            checkCancelled = true;
        }
    }


    private IEnumerator checkOut()
    {

        
        transform.position = Vector3.MoveTowards(transform.position, finishLine.position, speed * Time.deltaTime);

        yield return new WaitForSeconds(3);

        Destroy(gameObject);

    }
}
