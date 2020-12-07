using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    [TextArea(3, 10)]
    public string texto;
    
    public Text textoPainel;
    public GameObject painel;
    bool paused = false;
    PlayerController playerScript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        painel.SetActive(false);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
       
        
    }

    private void Update()
    {
        if(paused)
        {
            playerScript.enabled = false;

            if(Input.GetMouseButtonDown(0))
            {
                playerScript.enabled = true;
                paused = false;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            paused = true;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            textoPainel.text = texto;
            painel.SetActive(true);


        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            painel.SetActive(false);
            paused = false;
            this.enabled = false;
        }
            
    }


}
