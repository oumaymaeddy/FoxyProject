using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleurPiege : MonoBehaviour
{
    public float dommages = 0.2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControleurDommages controleurDommages = collision.gameObject.GetComponent<ControleurDommages>();
        if (controleurDommages != null)
        {
            controleurDommages.AppliquerDommages(dommages);
        }
     
        Debug.Log("Collision avec spikes avec " + collision.name);

      

        
    }
}