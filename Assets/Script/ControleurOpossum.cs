using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurOpossum : MonoBehaviour
{
    public float Dommages = 0.5f;
    public GameObject BorneGauche;
    public GameObject BorneDroite;
    public GameObject Oppossum;
    public float Vitesse = 5;
    private Rigidbody2D rigidBody;
    private bool versGauche = true;
    private SpriteRenderer spriteRenderer;
    public float DureeDeplacements = 3f;
    private float compteurDeplacements;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = Oppossum.GetComponent<SpriteRenderer>();
       compteurDeplacements = DureeDeplacements;
        BorneGauche.transform.parent = null;
        BorneDroite.transform.parent = null;
    }
    void Update()
    {
        if (compteurDeplacements > 0)
        {
            compteurDeplacements -= Time.deltaTime;
            if (versGauche)
            {
                rigidBody.velocity = new Vector2(-Vitesse, 0f);
                if (transform.position.x <= BorneGauche.transform.position.x)
                    ChangerDirection();
            }
            else
            {
                rigidBody.velocity = new Vector2(Vitesse, 0f);
                if (transform.position.x >= BorneDroite.transform.position.x)
                    ChangerDirection();
            }
        }
        else
        {
            ChangerDirection();
        }
        spriteRenderer.flipX = !versGauche;
    }

        //if (rigidBody.velocity.x < 0f)
        //    spriteRenderer.flipX = false;
        //else if (rigidBody.velocity.x > 0f)
        //    spriteRenderer.flipX = true;
    
    private void ChangerDirection()
    {
        compteurDeplacements = Random.Range(DureeDeplacements * 0.5f,
        DureeDeplacements * 1.5f);
        versGauche = !versGauche;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControleurDommages controleurDommages =
        collision.gameObject.GetComponent<ControleurDommages>();
        if (controleurDommages != null)
            controleurDommages.AppliquerDommages(Dommages);
    }
}




