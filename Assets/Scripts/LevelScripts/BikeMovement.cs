using UnityEngine;
using UnityEngine.SceneManagement;

public class BikeController : MonoBehaviour
{
    [Header("References")]
    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;

    [Header("Bike Properties")]
    public float accelerationForce = 200f;
    public float brakeForce = 300f;
    public float maxSpeed = 1500f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;
    private bool isBraking = false;

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
        float motorSpeed = 0f;
        float input = Input.GetAxis("Horizontal");

        if (input > 0)
        {
            motorSpeed = -accelerationForce;
            isBraking = false;
        }
        else if (input < 0)
        {
            motorSpeed = 0;
            if (!isBraking)
            {
                FindObjectOfType<AudioManager>().Play("brake");
                isBraking = true;
            }
        }
        else
        {
            isBraking = false;
        }

        if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            motorSpeed = 0f;
        }

        JointMotor2D motor = backWheel.motor;
        motor.motorSpeed = motorSpeed;
        motor.maxMotorTorque = Mathf.Abs(motorSpeed) > 0 ? brakeForce : accelerationForce;
        backWheel.motor = motor;

        backWheel.useMotor = input != 0;
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
