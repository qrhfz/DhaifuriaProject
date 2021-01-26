using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int hp;
    Text Hptower;

    // Start is called before the first frame update
    void Start()
    {
        Hptower = GameObject.Find("Hptower").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Hptower.text = "HP Tower " + hp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slime")
        {
            Debug.Log("hp tower = "+hp.ToString());
            hp--;


        }
    }
}
