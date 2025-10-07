using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurDommages : MonoBehaviour
{
    public bool aLaGemme = false; 

    public GameObject gemmeIndicateur; 

    private SpriteRenderer spriteRend;
    [SerializeField]
    private int viesRestantes = 3;
    public int ViesRestantes
    {
        get { return viesRestantes; }
        set
        {
            viesRestantes = value;
            gameObject.SetActive(viesRestantes >= 0);
            gameObject.SetActive(viesRestantes >= 0);
            if (viesRestantes < 0)
                GestionnaireAudio.instance.JouerEffetSonore(8);
            else
                GestionnaireJeu.instance.AfficherNombreVies(ViesRestantes);
        }
    }
    [SerializeField]
    private float dommages = 0f;
    public float Dommages
    {
        get { return dommages; }
        set
        {
            Debug.Log("Dommages appliques : " + value);

            dommages = Mathf.Clamp(value, 0f, 1f);
            if (dommages >= 1f)
            {
                ViesRestantes--;
                dommages = 0f;
            }
            GestionnaireAudio.instance.JouerEffetSonore(9);
            GestionnaireJeu.instance.AfficherDommages(dommages);

        }
    }
    private void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
    }

    public float DureeInvincibilite = 1f;
    private float compteurInvincibilite;
    private bool Invincible
    {
        get { return (compteurInvincibilite > 0f); }
        set
        {
            if (value)
                compteurInvincibilite = DureeInvincibilite;
            else
                compteurInvincibilite = 0f;
            float alpha = value ? 0.5f : 1f;
            spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g,
            spriteRend.color.b, alpha);

        }
    }

    private void Update()
    {
        if (Invincible)
        {
            compteurInvincibilite -= Time.deltaTime;
            if (compteurInvincibilite <= 0f)
                Invincible = false;
        }
    }
    public void Guerir()
    {
        Dommages = 0f;
        GestionnaireAudio.instance.JouerEffetSonore(7);

    }



    public void AppliquerDommages(float valeur)
    {

        if (!Invincible)
        {

            Dommages += valeur;
            //if(Dommages>=1f)
            //{
            //    GestionnaireAudio.instance.JouerEffetSonore(8);
            //}
            Invincible = true;
            GestionnaireAudio.instance.JouerEffetSonore(9);


        }
    }
    public void Ramasse()
    {
        aLaGemme = true;
        gemmeIndicateur.SetActive(true);
    }
    public void PerdreGemme()
    {
        aLaGemme = false;
        gemmeIndicateur.SetActive(false);
    }



}




