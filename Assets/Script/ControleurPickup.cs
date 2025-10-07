using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurPickup : MonoBehaviour
{
    public float DureeDesactivation = 15f;
    public bool Recurrence = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControleurDommages controleurDommages =
        collision.gameObject.GetComponent<ControleurDommages>();
        if (controleurDommages != null)
        {
            controleurDommages.Guerir();
            if (Recurrence)
                //gameObject.SetActive(false);
                GestionnaireJeu.instance.Suspendre(gameObject, DureeDesactivation);
            else
                Destroy(gameObject);
        }
        }
    }
          

