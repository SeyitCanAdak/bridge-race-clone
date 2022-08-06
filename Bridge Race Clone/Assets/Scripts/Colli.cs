using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colli : MonoBehaviour
{
    BoxCollider temp;
    public GameObject boxPrefab;
    public GameObject[] boxes;
    int i = 0;
    void Start() 
    {

    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Red"))
        {
            Destroy(other.gameObject);
            Instantiate(boxPrefab,boxes[i].transform.position,Quaternion.identity);
            i++;
        }
        else if(other.gameObject.CompareTag("Green"))
        {
            temp = other.gameObject.GetComponent<BoxCollider>();
            temp.enabled = false;
        }
        else if(other.gameObject.CompareTag("Blue"))
        {
            temp = other.gameObject.GetComponent<BoxCollider>();
            temp.enabled = false;
        }
        else if(other.gameObject.CompareTag("Yellow"))
        {
            temp = other.gameObject.GetComponent<BoxCollider>();
            temp.enabled = false;
        }
    }
}
