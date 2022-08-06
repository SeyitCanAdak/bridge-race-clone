using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    public Transform itemHoldingPosition;
    public int numberOfItemsHolding = 0;
    public int obstacleNumber;
    BagSpawner spawner;
    void Start()
    {
        spawner = FindObjectOfType<BagSpawner>();   
    }
    public void AddNewItem(Transform itemToAdd)
    {
        numberOfItemsHolding++;
        spawner.prefabCount--;
        var temp =  new Vector3(0, .05f * numberOfItemsHolding, 0);
        itemToAdd.DOJump(itemHoldingPosition.position + temp, 1.5f, 1, .25f).OnComplete(
            ()=>{
                itemToAdd.SetParent(itemHoldingPosition, true);//?? true niye
                itemToAdd.localPosition = temp;
                itemToAdd.localRotation = Quaternion.identity;
            }
        );  
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Bridge") && numberOfItemsHolding > 0)
        {
            numberOfItemsHolding--;
            obstacleNumber = itemHoldingPosition.transform.childCount;
            Destroy(itemHoldingPosition.transform.GetChild(obstacleNumber - 1).gameObject);
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if(other.gameObject.CompareTag("Obstacle") && numberOfItemsHolding > 0)
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
