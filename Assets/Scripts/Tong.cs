using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tong : MonoBehaviour
{
    public Animator anim;
    public GameObject hpp, spp;
    public AudioSource pecah;
    bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("tong_gone"))
        {
            active = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            if (!pecah.isPlaying)
            {
                Destroy(gameObject);
            }
        }
            
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {


        if (coll.gameObject.tag == "bullet")
        {
            if(!pecah.isPlaying)
                pecah.Play();

            anim.SetBool("isDestroyed", true);
            float randomPicker = Random.Range(0f, 1f);
            //Debug.Log(randomPicker);
            if (active)
            {
                if (randomPicker > 0.65)
                {
                    Instantiate(hpp, gameObject.transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(spp, gameObject.transform.position, Quaternion.identity);
                }
                Destroy(coll.gameObject);
            }
            
            
            

        }


    }
}
