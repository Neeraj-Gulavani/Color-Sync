using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{
    private Renderer r;
    public static string playerColour;
    private CinemachineImpulseSource impulseSrc;
    // Start is called before the first frame update
    void Awake()
    {
        r = GetComponent<Renderer>();
        playerColour = r.material.name.Replace(" (Instance)", "").ToLower();
        impulseSrc =GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        impulseSrc.GenerateImpulseWithForce(1f);
        ColorAssign scr = other.GetComponent<ColorAssign>();
        if (scr!=null) {
            string playerMatName = r.material.name.Replace(" (Instance)", "").ToLower();
            string objMatName = scr.color.Replace("Color","").ToLower();
            Debug.Log("Player : "+playerMatName);
            Debug.Log("Crashed obj : "+objMatName);
            if (playerMatName==objMatName) {
                Debug.Log("nice");
            } else {
                GameManager.instance.pscore = PlayerMovement.score;
                SceneManager.LoadScene("Lose");
            }
        
        Color c;
        if (ColorUtility.TryParseHtmlString(objMatName, out c))
            {
                var main= scr.transform.Find("CollectVFX").GetComponent<ParticleSystem>().main;
                main.startColor = c;
            }
            scr.transform.Find("CollectVFX").GetComponent<ParticleSystem>().Clear();
        scr.transform.Find("CollectVFX").GetComponent<ParticleSystem>().Play();
        scr.gameObject.SetActive(false);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        impulseSrc.GenerateImpulseWithForce(1f);
    }
}
