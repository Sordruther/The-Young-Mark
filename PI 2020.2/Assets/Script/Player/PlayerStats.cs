using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Sprite heartFull;
    public Sprite heartEmpty;

    private float currentHealth;

    public Animator anim;

    private GameManager GM;

    private void Start()
    {
        currentHealth = maxHealth;
        heart2.enabled = false;
        heart3.enabled =false;
        heart4.enabled = false;

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        anim.SetBool("knockback", true);

        if(currentHealth == 20f)
        {
            heart1.enabled = false;
            heart2.enabled = true;
        }

        if(currentHealth == 10f)
        {
            heart2.enabled = false;
            heart3.enabled = true;
        }

        if(currentHealth <= 0f)
        {
            heart3.enabled = false;
            heart4.enabled = true;
            Die();
        }
    }

    private void Die()
    {
        //animação de morte
        anim.SetBool("isDead", true);
        GM.Respawn();
        Destroy(gameObject);
    }
}
