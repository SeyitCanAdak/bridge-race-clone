using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSpawner : MonoBehaviour
{
    public GameObject bagPrefab;
    public GameObject yellowBag;
    public GameObject greenBag;
    public GameObject blueBag;
    Collector collectorScript;
    public GameObject bagSpawner;
    public int prefabCount = 0;
    void Start()
    {
        collectorScript = FindObjectOfType<Collector>();
        RealSpawner();
        YellowSpawner();
        GreenSpawner();
        BlueSpawner();
    }
    void Update() 
    {
        if(prefabCount < 1 && collectorScript.numberOfItemsHolding < 1)
        {
            RealSpawner();
        }
    }
    void RealSpawner()
    {   
        for(int i=0;i<8;i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-3.2f,4.2f), 0.65f, Random.Range(-3.2f,4.2f));
            Instantiate(bagPrefab, randomSpawnPos, Quaternion.identity);
            prefabCount = 3;
        }
    }
    void YellowSpawner()
    {
        for(int i=0;i<12;i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-3.2f,4.2f), 0.42f, Random.Range(-3.2f,4.2f));
            Instantiate(yellowBag, randomSpawnPos, Quaternion.identity);
        }
    }
    void GreenSpawner()
    {
        for(int i=0;i<12;i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-3.2f,4.2f), 0.42f, Random.Range(-3.2f,4.2f));
            Instantiate(greenBag, randomSpawnPos, Quaternion.identity);
        }
    }
    void BlueSpawner()
    {
        for(int i=0;i<12;i++)
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-3.2f,4.2f), 0.42f, Random.Range(-3.2f,4.2f));
            Instantiate(blueBag, randomSpawnPos, Quaternion.identity);
        }
    }
}
