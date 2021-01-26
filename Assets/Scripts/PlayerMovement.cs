using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float moveSpeed = 10;
    public Vector2 mouse;
    public Camera cam;
    public GameObject bullet;
    float speedFxTime = 0;
    float walkSoundTime = 0f;
    public int hp=1;
    public AudioClip walkSound, weaponSound, itemPickSound;
    public AudioSource audioSource;
    public Text TextHp;

    bool facingRight=true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        TextHp = GameObject.Find("HpText").GetComponent<Text>();
        Destroy(GameObject.Find("RetroMusic"));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = (Vector2)(Input.mousePosition - screenPoint);
        direction.Normalize();


        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);
        movement = movement.normalized;

        if (speedFxTime > 0)
        {
            moveSpeed = 15;
            speedFxTime -= Time.deltaTime;
        }
        else
        {
            moveSpeed = 10;
        }


        //On X axis: -1f is left, 1f is right


        //Player Movement. Check for horizontal movement
        //if (mouse.x > 0.5f || mouse.y < -0.5f)
        //{

            if (direction.x > 0f && !facingRight)
            {
                //If we're moving right but not facing right, flip the sprite and set     facingRight to true.
                Flip();
                facingRight = true;
            }
            else if (direction.x < 0f && facingRight)
            {
                //If we're moving left but not facing left, flip the sprite and set facingRight to false.
                Flip();
                facingRight = false;
            }

            //If we're not moving horizontally, check for vertical movement. The "else if" stops diagonal movement. Change to "if" to allow diagonal movement.
        //}


        
        //Variables for the animator to use as params
        anim.SetFloat("Horizontal", Mathf.Abs(direction.x) );
        anim.SetFloat("Vertical", direction.y);
        anim.SetFloat("Magnitude", direction.magnitude);
        anim.SetFloat("Movement", movement.magnitude);

        if (Mathf.Rad2Deg * Mathf.Atan(direction.y / direction.x)>67.5f||Mathf.Rad2Deg* Mathf.Atan(direction.y / direction.x) < -67.5f)
        {
            gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector2(0, -0.0475f);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.transform.localPosition = new Vector2(0.05f, -0.0475f);
        }

        if (movement.magnitude > 0)
        {
            transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
            

            if (walkSoundTime == 0f)
            {
                audioSource.PlayOneShot(walkSound, 0.5f);
                walkSoundTime += Time.deltaTime;
            }
            else if(walkSoundTime < walkSound.length)
            {
                walkSoundTime += Time.deltaTime;
            }
            else if(walkSoundTime >= walkSound.length)
            {
                walkSoundTime = 0f;
            }
        }


        if (Input.GetKeyDown("mouse 0"))
        {
            //Debug.Log("cia cia cia");

            GameObject obj = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
            obj.GetComponent<Ammo>().RecieveBulletParameter(direction);
            audioSource.PlayOneShot(weaponSound);
        }

        if (hp == 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("resultLose");
            DontDestroyOnLoad(GameObject.Find("getLevel"));
        }

        TextHp.text = "X " + hp;

    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "slime")
        {
            Debug.Log("hp berkurang");
            hp--;

            Vector2 dir = collision.contacts[0].point - (Vector2)transform.position;
            dir = -dir.normalized;

            Debug.Log("x = " + dir.x + " y = " + dir.y);

            gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 5f, ForceMode2D.Impulse);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "hpp")
        {
            audioSource.PlayOneShot(itemPickSound, 0.25f);
            Destroy(collision.gameObject);
            Debug.Log("HP bertambahr");
            hp++;

        }

        if(collision.gameObject.tag == "spp")
        {
            audioSource.PlayOneShot(itemPickSound, 0.25f);
            Destroy(collision.gameObject);
            Debug.Log("Speed boost");
            speedFxTime = 10;
            

        }
    }
}
