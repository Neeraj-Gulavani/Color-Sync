using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Renderer r;
    public static string playerColour;
    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Renderer>();
        playerColour = r.material.name.Replace(" (Instance)", "").ToLower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        ColorAssign scr = other.GetComponent<ColorAssign>();
        if (scr!=null) {
            string playerMatName = r.material.name.Replace(" (Instance)", "").ToLower();
            string objMatName = scr.color.Replace("Color","").ToLower();
            Debug.Log("Player : "+playerMatName);
            Debug.Log("Crashed obj : "+objMatName);
            if (playerMatName==objMatName) {
                Debug.Log("nice");
            } else {
                SceneManager.LoadScene("Lose");
            }
        scr.gameObject.SetActive(false);
        }
        
    }
}
