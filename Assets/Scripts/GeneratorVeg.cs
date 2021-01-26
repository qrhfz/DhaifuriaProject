using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorVeg : MonoBehaviour
{
    public GameObject o1, o2, o3, o4, o5, o6, o7;
    GameObject[] obs = new GameObject[7];
    // Start is called before the first frame update
    void Start()
    {
        obs[0] = o1;
        obs[1] = o2;
        obs[2] = o3;
        obs[3] = o4;
        obs[4] = o5;
        obs[5] = o6;
        obs[6] = o7;

        int i = 0;
        for (i = 0; i < 100; i++)
        {
            int pick = Random.Range(0, 7);
            Instantiate(obs[pick], new Vector2(Random.Range(-25, 25), Random.Range(-25, 25)), Quaternion.identity);
        }
        //Instantiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
