using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] float randomDeviation = 0.5f;

    Vector2 paddleToBallDistance;
    bool hasStarted = false;

    AudioSource audioSource;
    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidBody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleToBallDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomDeviation), 
            Random.Range(0f, randomDeviation));
        if (hasStarted)
        {
            AudioClip clip = collisionSounds[UnityEngine.Random.Range(0, collisionSounds.Length)];
            audioSource.PlayOneShot(clip);
            rigidBody2D.velocity += velocityTweak;
        }      
    }
}
