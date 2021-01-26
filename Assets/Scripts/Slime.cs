using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    GameObject player,  tower;
    public GameObject explosion;
    public float moveSpeed;
    Vector3 d;
    int target;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("player");
        tower = GameObject.FindWithTag("tower");
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        target = caster(transform.position, 5f);
        if (target == 0)
        {
            incarPlayer();
        }
        else if(target == 1)
        {
            incarTowe();
        }
        else
        {

        }

    }

    int caster(Vector2 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        int i = 0;

        while (i < hitColliders.Length)
        {

            if (hitColliders[i].tag == "player")
            {
                return 0;
            }

            i++;
        }

        return 1;
    }

    void incarTowe()
    {
        //Debug.Log("incar tower");
        d = tower.transform.position - transform.position;
        d = d.normalized;
        transform.position = transform.position + d * moveSpeed * Time.deltaTime;
    }

    void incarPlayer()
    {
        //Debug.Log("incar player");
        d = player.transform.position - transform.position;
        d = d.normalized;
        transform.position = transform.position + d * moveSpeed * Time.deltaTime;
    }


    public void RecieveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "tower" || collision.gameObject.tag == "player")
        {
            Meledak();
        }
        
    }

    public void Meledak()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}

