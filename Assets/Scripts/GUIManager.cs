using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public bool isMenang=false;
    public Button blvl1, blvl2, blvl3;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("level", 1);
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }

        
        try {
            blvl1 = GameObject.Find("lvl1").GetComponent<Button>();
            blvl2 = GameObject.Find("lvl2").GetComponent<Button>();
            blvl3 = GameObject.Find("lvl3").GetComponent<Button>();
            blvl1.interactable = blvl2.interactable = blvl3.interactable = false;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log(ex.Message);
        }


        if (PlayerPrefs.HasKey("level"))
        {
            int levelState = PlayerPrefs.GetInt("level");
            try
            {
                switch (levelState)
                {
                    case 1:
                        blvl1.interactable = true;
                        break;
                    case 2:
                        blvl1.interactable = true;
                        blvl2.interactable = true;
                        break;
                    case 3:
                        blvl1.interactable = true;
                        blvl2.interactable = true;
                        blvl3.interactable = true;
                        break;
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }
        
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play(){
        SceneManager.LoadScene("level");
    }
    public void Credit(){
        SceneManager.LoadScene("credit");
    }
    public void Help(){
        SceneManager.LoadScene("help");
    }
    public void Back(){
        SceneManager.LoadScene("landing");
    }
    public void lvl1(){
        SceneManager.LoadScene("Level1");
    }
    public void lvl2(){
        SceneManager.LoadScene("Level2");
    }
    public void lvl3(){
        SceneManager.LoadScene("Level3");
    }
    public void quit()
    {
        //Application.Quit();
    }
    public void menu()
    {
        SceneManager.LoadScene("landing");
    }
    public void ulang()
    {
        Debug.Log(GameObject.Find("getLevel").GetComponent<Getlevel>().level);
        if (GameObject.Find("getLevel").GetComponent<Getlevel>().level==1)
        {
            SceneManager.LoadScene("Level1");
        }
        else if (GameObject.Find("getLevel").GetComponent<Getlevel>().level == 2)
        {
            
            SceneManager.LoadScene("Level2");
        }
        else if (GameObject.Find("getLevel").GetComponent<Getlevel>().level == 3)
        {
            SceneManager.LoadScene("Level3");
        }
    }
    public void next()
    {
        SceneManager.LoadScene("level");
    }
}
