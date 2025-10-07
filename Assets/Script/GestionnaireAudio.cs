using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestionnaireAudio : MonoBehaviour {
 public static GestionnaireAudio instance;
public AudioSource[] effetsSonores;
private void Awake()
{
    instance = this;
}
public void JouerEffetSonore(int index)
{
    effetsSonores[index].Stop(); // au cas où il joue déjà
    effetsSonores[index].Play();
}
}
