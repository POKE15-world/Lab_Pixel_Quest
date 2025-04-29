using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
    string varibaleone = "hello";
    int varone = 0;
    int vartwo = 5;
    public int speed = 5;
    public int deathCount = 0; 
    public string nextlevel = "Scene 2";
    private UIDEATHcounter UIDEATHcounter;
    
    // Start is called before the first frame update
    void Start()
    {
        UIDEATHcounter = GetComponent<UIDEATHcounter>(); 
        if (SceneManager.GetActiveScene().name == "Scene_1" && PlayerPrefs.GetInt("DeathCount") <= 0)
        {
            PlayerPrefs.SetInt("DeathCount", 0);
            deathCount = 0;
        }
        else
        {
            deathCount = PlayerPrefs.GetInt("DeathCount");
        }
        UIDEATHcounter.SetDeathText(deathCount);

        Debug.Log(" world ");
        string varibaltwo = "world";
        Debug.Log(varibaleone + varibaltwo);
        rb = GetComponent<Rigidbody2D>();
    }


    private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        //Debug.Log(xinput);
        rb.velocity = new Vector2(xinput * speed, rb.velocity.y);

        /*
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(1, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
        }

          Debug.Log(varone);
          varone++;
        }*/
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = Vector2.up * 4;

        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        switch (collision.tag)
        {
            case "Death":
                {
                    deathCount++;
                    PlayerPrefs.SetInt("DeathCount", deathCount);
                    UIDEATHcounter.SetDeathText(deathCount);
                    string thislevel = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(thislevel);
                    Debug.Log("Player Has Died");
                    break;
                }
            case "Finish":
                {
                    SceneManager.LoadScene(nextlevel);
                    break;
                }
        }




    }
}