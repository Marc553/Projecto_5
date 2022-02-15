using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 2f;
    private GameManager gameManagerScript;

    void Start()
    {
        //Autodestruccion tras 2s
        Destroy(gameObject, lifeTime);
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseSDown()
    {
        Destroy(gameObject);

        if(gameObject.CompareTag("Bad"))
        {
            gameManagerScript.isGameOver = true;
        }
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }

}
