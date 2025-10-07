using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AffichageEtatJoueur : MonoBehaviour
{
        public GameObject NombreViesText;
       public GameObject DommagesGlissiere;
    private Slider dommagesSlider;
    private Text nombreViesText;
    private void Start()
    {
        nombreViesText = NombreViesText.GetComponent<Text>();
        dommagesSlider = DommagesGlissiere.GetComponent<Slider>();
    }
    public void AfficherNombreVies(int nbVies)
        {
        if (nbVies >= 0)

            nombreViesText.text = nbVies.ToString();
        else nombreViesText.text = "";
        }
   
    public void AfficherDommages(float dommages)
    {
        dommagesSlider.value = dommages;
    }
}
    