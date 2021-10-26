using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    public int lineNum;
    public int rowNum;

    private bool gameOver;
    private float lastSpawn;

    private int objectNum;

    public GameObject[] ObjectPrefabs;


    private Vector3Int InitiatePosition;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Time.realtimeSinceStartup - lastSpawn >= 1.0f)
            {
                GenerateRandomPosition();
                GenerateRandomObject();
                lastSpawn = Time.realtimeSinceStartup;
            }

        }
        else
        {
            return;
        }


    }

    public void GenerateRandomPosition()
    {
        InitiatePosition = new Vector3Int(Random.Range(-lineNum, lineNum), Random.Range(-lineNum, lineNum), 0);
        Debug.Log(InitiatePosition);
    }
    public void GenerateRandomObject()
    {
        //Generate a random ObjectNum
        objectNum = Random.Range(0, ObjectPrefabs.Length);
        Debug.Log("ObjectNumber is " + objectNum);

        //Instantiate the objectPrefab from an array according to the random object number
        InstantiateObject();
        //place the object at the locatoin

    }
    public void InstantiateObject()
    {
        GameObject spawnObject =  Instantiate(ObjectPrefabs[objectNum], InitiatePosition, Quaternion.identity);
    }
}
