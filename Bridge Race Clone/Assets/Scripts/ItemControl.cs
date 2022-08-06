using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    bool isAlreadyCollected = false;
    private void OnTriggerEnter(Collider other) {

        if(isAlreadyCollected) return;

        if(other.CompareTag("Player"))
        {
            Collector collect;
            if(other.TryGetComponent(out collect))
            {
                collect.AddNewItem(this.transform);
                isAlreadyCollected = true;
            }
        }
    }
}
