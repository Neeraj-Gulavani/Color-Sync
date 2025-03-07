using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoredisplay : MonoBehaviour
{
    public TMP_Text t;
    // Start is called before the first frame update
    void Start()
    {
        t.text = GameManager.instance.pscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
