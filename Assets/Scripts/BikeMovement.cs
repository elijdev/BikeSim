using UnityEngine;

public class BikeController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 5f;
    [SerializeField] float minSpeed = 0f;
    Rigidbody2D rb;
    float currentSpeed = 0f;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pauseButton;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveBike();
    }


    private void MoveBike()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            currentSpeed -= deceleration * Time.fixedDeltaTime;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += acceleration * Time.fixedDeltaTime;
        }
        else
        {
            currentSpeed -= deceleration/1.5f * Time.fixedDeltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            pauseButton.SetActive(false);

        }
    }
}
