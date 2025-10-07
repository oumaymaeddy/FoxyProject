using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurGem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        ControleurDommages controleurDommages =
        collision.gameObject.GetComponent<ControleurDommages>();
        if (controleurDommages != null)
        {
            controleurDommages.Ramasse();
            gameObject.SetActive(false);


        }
    }
}