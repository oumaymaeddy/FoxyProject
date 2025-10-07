using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform cible;
    public Transform arriereProfond, arriereProche;
    private Vector2 dernierePos;
    public float minPositionY, maxPositionY;
    private float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        dernierePos = transform.position;
        deltaY = transform.position.y - cible.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float yPos = Mathf.Clamp(cible.position.y+deltaY, minPositionY, maxPositionY);
        transform.position = new Vector3(cible.position.x,yPos,
     transform.position.z);
        Vector2 deltaPos = new Vector2(transform.position.x - dernierePos.x,
        transform.position.y - dernierePos.y);
        arriereProfond.position += new Vector3(deltaPos.x, deltaPos.y, 0f);
        arriereProche.position += new Vector3(deltaPos.x, deltaPos.y, 0f) * 0.5f;
        dernierePos = transform.position;
    }
}
