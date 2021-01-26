using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    Vector2 d;

    // Start is called before the first frame update
    void Start()
    {
        
       GetComponent<Rigidbody2D>().velocity = d*100f;
        
    }

    private void Awake()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecieveBulletParameter(Vector2 d)
    {
        this.d = d;
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "slime")
        {

            Destroy(gameObject);
            coll.gameObject.GetComponent<Slime>().Meledak();
            
            
        }

        if (coll.gameObject.tag == "tower")
        {

            Destroy(gameObject);



        }


    }

}
