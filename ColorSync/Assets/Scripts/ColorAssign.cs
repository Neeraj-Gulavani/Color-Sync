using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAssign : MonoBehaviour
{
    public ParticleSystem collectvfx;
    public string color;
    void Start()
    {
        
    }

    public void DestroyBall(Color c) {
        ParticleSystem a = Instantiate(collectvfx,transform.position,Quaternion.identity);
        var b = a.main;
        b.startColor = c;
        Destroy(gameObject);

    }
    void OnDestroy() {
        
    }

}
