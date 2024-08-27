using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallStand : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> standPlaces = new List<GameObject>();
    public int standCounter;
    public int standCount = 0;
    [SerializeField] private GameObject mallStandPrefab;


    public Queue<Transform> mallObjQueue = new Queue<Transform>();
    public Stack<GameObject> mallObjects = new Stack<GameObject>();


    public Color hoverColor = Color.red;
    private Color originalColor;
    private Renderer objectRenderer;


    private bool hoverCursor = false;


    void Start()
    {
        /*
        for (int i = 0; i < standPlaces.Count; i++)
        {
            GameObject objStand = Instantiate(mallStandPrefab, standPlaces[i].transform.position, Quaternion.identity);
            objStand.transform.parent = standPlaces[i].transform;
        }
        */



        objectRenderer = GetComponent<Renderer>();

        originalColor = objectRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        standCounter = mallObjects.Count;

        if (Input.GetMouseButtonDown(0) && hoverCursor && mallObjects.Count <= 4)
        {
            GameObject objStand = Instantiate(mallStandPrefab, standPlaces[standCounter].transform.position, Quaternion.identity);
            objStand.transform.parent = standPlaces[standCounter].transform;
            mallObjects.Push(objStand);
            standCount++;
        }

        if (Input.GetMouseButtonDown(1) && hoverCursor && mallObjects.Count > 0)
        {
            TryPop();
            standCount--;
        }

    }

    void OnMouseEnter()
    {

        objectRenderer.material.color = hoverColor;
        hoverCursor = true;

        
    }

    void OnMouseExit()
    {

        objectRenderer.material.color = originalColor;
        hoverCursor = false;
    }

    private void TryPop()
    {
        if (mallObjects.TryPop(out GameObject poppedObject))
        {
            Destroy(poppedObject);
            //mallStand.standCounter =0;


        }
        else
        {
           
        }
    }
}
