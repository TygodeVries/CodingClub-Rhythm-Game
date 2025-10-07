using UnityEngine;

public class Note : MonoBehaviour
{
    // Updates every FRAME
    void Update()
    {
        float deltaTime = Time.deltaTime;
        
        // Usefull side effect, we now move 3 units / second
        transform.Translate(0, -3 * deltaTime, 0);

        if(transform.position.y < -5)
        {
            // We missed the note!
            score.RemoveScore(1000); // Remove the score
            Destroy(gameObject); // Destroy ourselfs
        }
    }

    Score score;
    private void Start()
    { 
        score = FindAnyObjectByType<Score>();
    }
}
