using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateSpawner : MonoBehaviour
{
    public GameObject spawnPt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GameManager.SpawnNextTemplate(spawnPt.transform.position, transform.gameObject);
        }
    }
}
