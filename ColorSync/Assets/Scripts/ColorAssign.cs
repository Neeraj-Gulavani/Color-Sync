using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssign : MonoBehaviour
{
    public Material[] mats;
    public string color;
    private Renderer r;
    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Start()
    {
        if (mats.Length>0) {
            Material mat = mats[Random.Range(0, mats.Length)];
            r.material = mat;
            color = mat.name;
        }
    }
}
