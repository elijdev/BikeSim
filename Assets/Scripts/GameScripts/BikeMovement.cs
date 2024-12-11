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
    public float maxSpeed = 15f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;

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
        }
        else if (input < 0)
        {
            motorSpeed = accelerationForce;
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
