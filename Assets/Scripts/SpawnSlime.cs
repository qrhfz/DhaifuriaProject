using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{
    public GameObject BlueSlime,RedSlime,GreenSlime;
    public float moveSpeed, rate;
    int randomPicker;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateSlime", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateSlime()
    {
        float randomTime = Random.Range(3f-rate, 9f-rate);

        GameObject obj;

        randomPicker = Random.Range(0, 3);
        if (randomPicker==0) {
            obj = (GameObject)Instantiate(BlueSlime, gameObject.transform.position, Quaternion.identity);
        }else if(randomPicker==1){
            obj = (GameObject)Instantiate(GreenSlime, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            obj = (GameObject)Instantiate(RedSlime, gameObject.transform.position, Quaternion.identity);
        }

        obj.GetComponent<Slime>().RecieveSpeed(moveSpeed);

        Invoke("CreateSlime", randomTime);



    }
}
