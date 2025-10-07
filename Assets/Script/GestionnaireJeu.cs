using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{

    public static GestionnaireJeu instance;
    public void Suspendre(GameObject objet, float secondes)
    {
        StartCoroutine(SuspendreObjet(objet, secondes));
    }
    private void Awake()
    {
        instance = this;
    }
    private IEnumerator SuspendreObjet(GameObject objet, float secondes)
    {
        objet.SetActive(false);
        yield return new WaitForSeconds(secondes);
        objet.SetActive(true);
    }
    public void AfficherNombreVies(int nbVies)
    {
        AffichageEtatJoueur affEtatJoueur = instance.GetComponent<AffichageEtatJoueur>();
        affEtatJoueur.AfficherNombreVies(nbVies);
    }
    public void AfficherDommages(float dommages)
    {
        AffichageEtatJoueur affEtatJoueur = instance.GetComponent<AffichageEtatJoueur>();
        affEtatJoueur.AfficherDommages(dommages);
    }
}
