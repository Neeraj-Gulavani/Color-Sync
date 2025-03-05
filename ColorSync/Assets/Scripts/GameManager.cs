using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   
    public GameObject[] templates;
    public int pscore=0;
    void Start() {
        instance = this;
    }
    public static void SpawnNextTemplate(Vector3 pos, GameObject prevTemplate) {
        GameObject toSpawn = instance.templates[Random.Range(0,instance.templates.Length)];
        GameObject spawned = Instantiate(toSpawn,pos,Quaternion.identity);
        
    }

}
