using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;

    public Material[] mats;
    private List<Material> UsedCol = new List<Material>();
    private string pc;
    public GameObject colorBall;
    // Start is called before the first frame update
    void Awake() {
        spawnPoints = new List<GameObject>();
        Transform[] t = transform.GetComponentsInChildren<Transform>();
        foreach (Transform pt in t)
        {
            if (pt != transform)
            {
                spawnPoints.Add(pt.gameObject);
            }
        }
    }
    void Start()
    {
        pc = PlayerManager.playerColour;
        Debug.Log("Player Colour :" + pc);
        int count=0;
        List<Material> Remaining = new List<Material>(mats);
        foreach (GameObject s in spawnPoints) {
            GameObject obj = Instantiate(colorBall, s.transform.position, Quaternion.identity);
             if (Remaining.Count == 0)
            {
                Remaining = new List<Material>(mats);
                UsedCol.Clear();
            }
            if (Remaining.Count>0) {
            Material mat = Remaining[Random.Range(0, Remaining.Count)];
            if (UsedCol.Count>1) {
                Debug.Log("Used colours : "+ UsedCol);
                if (!UsedCol.Exists(col => col.name.Replace("Color","").ToLower().Trim()==pc)) {
                    foreach (Material m in mats) {
                        Debug.Log("Colour in array : "+m.name.Replace("Color","").ToLower().Trim());
                        if (m.name.Replace("Color","").ToLower().Trim()==pc) {
                            mat = m;
                            Debug.Log("Assigning player colour to the obj: " + m.name);
                        }
                    }
                }
            }
            Remaining.Remove(mat);
            Renderer r = obj.GetComponent<Renderer>();
            r.material = mat;
            UsedCol.Add(mat);
            obj.GetComponent<ColorAssign>().color = mat.name.Replace(" (Instance)", "").Trim();
            count++;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
