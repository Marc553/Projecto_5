using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points;
    public ParticleSystem esxprosionParticle;

    private float lifeTime = 2f;

    private GameManager gameManagerScript;

    void Start()
    {
        //Autodestruccion tras 2s
        Destroy(gameObject, lifeTime);
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (!gameManagerScript.isGameOver)
        {
            gameManagerScript.UpdateScore(points);
            Instantiate(esxprosionParticle, transform.position, esxprosionParticle.transform.rotation);

            Destroy(gameObject);

            if (gameObject.CompareTag("Bad"))
            {
                gameManagerScript.GameOver();

            }
        }
    }

    private void OnDestroy()
    {
        gameManagerScript.targetPositions.Remove(transform.position);
    }

}
