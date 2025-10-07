using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurJoueur : MonoBehaviour
{
    public float vitesseDeplacement = 7.5f;
    public float PuissanceSaut = 10f;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Transform checkPointSol;
    public LayerMask masqueDuSol;
    private bool estAuSol;
    private bool secondSautPermis = false;
    private AudioSource audioSource;
    public Transform gemme;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(vitesseDeplacement * Input.GetAxis("Horizontal"),
   rigidBody.velocity.y);
        estAuSol = Physics2D.OverlapCircle(checkPointSol.position, 0.2f, masqueDuSol);
        if (estAuSol)
        {
            secondSautPermis = true;
        }
        if (Input.GetButtonDown("Jump") && secondSautPermis)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, PuissanceSaut);
            if (!estAuSol)
                secondSautPermis = false;
            GestionnaireAudio.instance.JouerEffetSonore(10);
        }
        animator.SetFloat("vitesseDeplacement", Mathf.Abs(rigidBody.velocity.x));
        animator.SetBool("pattesAuSol",estAuSol);
        if (rigidBody.velocity.x > 0)
            spriteRenderer.flipX = false;
        else if (rigidBody.velocity.x < 0)
            spriteRenderer.flipX = true;



    }
}


