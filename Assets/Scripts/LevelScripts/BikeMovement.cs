using UnityEngine;
using UnityEngine.SceneManagement;

public class BikeController : MonoBehaviour
{
    [Header("References")]
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;

    [Header("Bike Properties")]
    public float accelerationForce = 600f;
    public float brakeForce = 300f;
    public float maxSpeed = 1500f;
    public float rotationSpeed = 200f;
    public float accelerationRate = 10f;

    private Rigidbody2D rb;
    private bool isBraking = false;
    private bool isMovingSFX = false;
    private float currentSpeed = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleRotation();
    }

    private void HandleMotor()
    {
        float input = Input.GetAxis("Horizontal");

        if (input > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, -maxSpeed, accelerationRate * Time.fixedDeltaTime);
            isBraking = false;
        }
        else if (input < 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, brakeForce * Time.fixedDeltaTime);
            if (!isBraking)
            {
                FindObjectOfType<AudioManager>().Play("brake");
                isBraking = true;
            }
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, accelerationRate * Time.fixedDeltaTime);
            isBraking = false;
        }

        JointMotor2D motor = backWheel.motor;
        motor.motorSpeed = currentSpeed;
        motor.maxMotorTorque = Mathf.Abs(currentSpeed) > 0 ? Mathf.Max(brakeForce, 1000f) : accelerationForce;
        backWheel.motor = motor;

        backWheel.useMotor = input != 0;

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        if (Mathf.Abs(rb.velocity.x) > 0.1f && !isBraking)
        {
            if (!isMovingSFX)
            {
                FindObjectOfType<AudioManager>().Play("moving");
                isMovingSFX = true;
            }
        }
        else
        {
            isMovingSFX = false;
            FindObjectOfType<AudioManager>().Stop("moving");
        }
    }

    private void HandleRotation()
    {
        float rotationInput = Input.GetAxis("Vertical");

        if (rotationInput != 0)
        {
            rb.AddTorque(-rotationInput * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collidable"))
        {
            FindObjectOfType<AudioManager>().Play("die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
