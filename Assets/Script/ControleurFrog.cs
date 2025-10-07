using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class ControleurFrog : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ControleurDommages controleurDommages = collision.gameObject.GetComponent<ControleurDommages>();
            if (controleurDommages != null && controleurDommages.aLaGemme)
            {
                controleurDommages.aLaGemme = false;
                controleurDommages.gemmeIndicateur.SetActive(false);
            }
            else
            {
             
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

}