using UnityEngine;

public class GroundPlayer : MonoBehaviour
{
    public Rigidbody body;
    public float speed = 2f;
    public float maxAccel = 20f;
    public float maxDeccel = 70f;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var rawInput = InputHandler.current.move.ReadValue<Vector2>();
        var worldInput = Camera.main.transform.TransformDirection(new Vector3(rawInput.x, 0, rawInput.y));
        worldInput.y = 0;

        Vector3 currentVelocity = body.linearVelocity;
        currentVelocity.y = 0;

        Vector3 goalVelocity = worldInput * speed;
        Vector3 aceleration = (goalVelocity - currentVelocity) / Time.fixedDeltaTime;

        float dot = Vector3.Dot(worldInput, currentVelocity);
        if (dot >= 0 && worldInput != Vector3.zero)
            aceleration = Vector3.ClampMagnitude(aceleration, maxAccel);
        else
            aceleration = Vector3.ClampMagnitude(aceleration, maxDeccel);

        //Ignore Vertical
        aceleration.y = 0;

        body.AddForce(body.mass * aceleration);
    }
}
