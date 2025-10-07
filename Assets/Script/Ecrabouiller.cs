using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecrabouiller : MonoBehaviour
{
    public float PuissanceBond = 10f;
    public GameObject Sfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform parentTransform = gameObject.transform.parent;
        Rigidbody2D rigidBody = parentTransform.GetComponent<Rigidbody2D>();
        if (collision.tag == "Ennemi" && rigidBody.velocity.y < 0f)
        {
            Destroy(collision.gameObject);
            GestionnaireAudio.instance.JouerEffetSonore(3);


            rigidBody.velocity = new Vector2(rigidBody.velocity.x, PuissanceBond);
            if (Sfx != null)
            {
                GameObject ennemi = collision.gameObject;
                GameObject sfx = Instantiate(Sfx, ennemi.transform.position,
                ennemi.transform.rotation);
                sfx.SetActive(true);
                StartCoroutine(SupprimerSfx(sfx));
            }
        }
    }
    private IEnumerator SupprimerSfx(GameObject sfx)
    {
        float secondes = 0f;
        Animator anim = sfx.GetComponent<Animator>();
        if (anim != null)
        {
            AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
            if (clips != null && clips.Length > 0)
                secondes = clips[0].length;
        }
        if (secondes > 0f)
            yield return new WaitForSeconds(secondes);
        Destroy(sfx);
    }
}


