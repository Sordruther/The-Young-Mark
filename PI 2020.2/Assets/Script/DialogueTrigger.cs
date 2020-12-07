﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public bool paused;

    PlayerController playerScript;
    PlayerCombatController PC;

    public GameObject continueButton;
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatController>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Type());
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            PC.enabled = false;
            playerScript.enabled = false;
            panel.SetActive(true); 
        }
    }

    private void Update()
    {

        if (PauseMenu.gameIsPaused)
        {
            textDisplay.enabled = false;
            panel.SetActive(false);
        }

        else if (textDisplay.text == sentences[index] && !PauseMenu.gameIsPaused)
        {
            textDisplay.enabled = true;
            panel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                NextSentence();
            }
            //continueButton.SetActive(true);
        }
    }

    

    IEnumerator Type()
    {


        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {

        //continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            //continueButton.SetActive(false);
            panel.SetActive(false);

            playerScript.enabled = true;
            PC.enabled = true;
            paused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}