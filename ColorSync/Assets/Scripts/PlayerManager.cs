using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Renderer r;
    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        ColorAssign scr = other.GetComponent<ColorAssign>();
        if (scr!=null) {
            if (scr.color.Replace("Color","")==r.material.name) {
                Debug.Log("nice");
            } else {
                Debug.Log("fail");
            }
        }
        scr.gameObject.SetActive(false);
    }
}
