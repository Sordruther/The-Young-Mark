using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rig; //pegar o rigidbody para as mecanicas do pulo
    public float JumpForce; //velocidade do pulo do jogador
    public float Speed; //velocidade do jogador com publico para editar na propria unity
    public bool isJumping; //pular 1 unica vez só quando esta no chão
    public Animator animator; //controle da animação
    public int life = 3;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite heartFull;
    public Sprite heartEmpty;







    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //Movimentação para a esquerda ou direita
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f)
        {

            animator.SetBool("walk", true); // animação andar
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            animator.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            animator.SetBool("walk", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

            animator.SetBool("Jumping", true);

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Damage();
            }
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }

    }
    public void Damage()
    {
        if (life > 1)
        {
            life--; // diminui o valor da variavel em uma unidade
            if (life == 2)
            {
                heart3.enabled = false;
            }
            else if (life == 1)
            {
                heart2.enabled = false;
            }
        }
        else
        {
            GameOver();
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("Game");
    }

   
}