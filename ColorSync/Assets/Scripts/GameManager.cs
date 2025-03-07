using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   
    public GameObject[] templates;
    public int pscore=0;
    public bool paused;
    public GameObject pauseMenu;
    public GameObject prevTemp;
    public GameObject prevPrevTemp;
    void Start() {
        instance = this;
    }
    public static void SpawnNextTemplate(Vector3 pos, GameObject prevTemplate) {
        if (instance.prevPrevTemp != null) {
            Destroy(instance.prevPrevTemp);
        }
         instance.prevPrevTemp = instance.prevTemp;
        GameObject toSpawn = instance.templates[Random.Range(0,instance.templates.Length)];
        instance.prevTemp = Instantiate(toSpawn,pos,Quaternion.identity);
        
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
    }

    public void TogglePause() {
        Time.timeScale = paused?1:0;
            paused=!paused;
            pauseMenu.SetActive(paused);
    }

}
