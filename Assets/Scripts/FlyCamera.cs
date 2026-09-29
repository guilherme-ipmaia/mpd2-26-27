using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public static FlyCamera current;

    public float moveSpeed = 5f;
    public float turnSpeed = 0.2f;
    public float sprintMult = 3f;
    public float slowtMult = 0.5f;

    public Rigidbody body;
    public Camera playerCamera;
    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        //Definir Temporariamente cursor
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

    }

    void Update()
    {
        Movement();
        Turn();
    }

    void Movement()
    {
        Vector2 inputRaw = InputHandler.current.move.ReadValue<Vector2>();

        //UP e DOWN input
        float upDownInput = 0;
        if (Input.GetKey(KeyCode.E))
            upDownInput = 1;
        else if (Input.GetKey(KeyCode.Q))
            upDownInput = -1;

        Vector3 input = new Vector3(inputRaw.x, upDownInput, inputRaw.y);

        //Translacao Input
        Vector3 worldInput = playerCamera.transform.TransformDirection(input);

        float speed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
            speed *= sprintMult;

        if (Input.GetKey(KeyCode.LeftControl))
            speed *= slowtMult;

        //Movimento
        body.linearVelocity = worldInput * speed;
        //transform.position += worldInput * speed * Time.deltaTime;
    }

    void Turn()
    {
        Vector2 inputRaw = InputHandler.current.look.ReadValue<Vector2>();

        Vector3 input = new Vector3(-inputRaw.y, inputRaw.x, 0) * turnSpeed * Time.deltaTime;

        //Criação Quaternions
        Quaternion yaw = Quaternion.Euler(0, inputRaw.x, 0);
        Quaternion pitch = Quaternion.Euler(-inputRaw.y, 0, 0);


        //Translacao Input
        //Ordem de Aplicacao de Rotacao
        playerCamera.transform.rotation = yaw * playerCamera.transform.rotation * pitch;

    }

}