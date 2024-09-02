using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
void Start()
{
    ballMovement = GetComponent<BallMovement>();
    scoreManager = FindObjectOfType<ScoreManager>();
    if(ballMovement == null)
    {
        Debug.LogError("BallMovement component is not assigned and not found on the same GameObject!");
    }

    if(scoreManager == null)
    {
        Debug.LogError("scoreManager component is not assigned and not found on the same GameObject!");
    }
}
    private void Bounce(Collision2D collision)
    {
        // Topun ve raketin pozisyonlarını alın
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;

        // Topun hangi oyuncuya (rakete) çarptığını belirleyin
        if (collision.gameObject.name == "Paddle1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        // Topun dikey pozisyonunu hesaplayın
        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        // Vuruş sayacını artırın ve topu yeni yöne hareket ettirin
        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Topun hangi oyuncunun raketine çarptığını kontrol edin
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            Bounce(collision);
        } 

        else if(collision.gameObject.name == "RightBorder") {
            scoreManager.paddle1Goal();
        }
        else if (collision.gameObject.name == "LeftBorder"){
            scoreManager.paddle2Goal();
        }
    }
}
