using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 0.2f;
    public float sprintMult = 3f;
    public float slowtMult = 0.5f;

    public Rigidbody body;
    public Camera playerCamera;

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
        //Leitura de input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //UP e DOWN input
        float upDownInput = 0;
        if (Input.GetKey(KeyCode.E))
            upDownInput = 1;
        else if (Input.GetKey(KeyCode.Q))
            upDownInput = -1;

        Vector3 input = new Vector3(x, upDownInput, y);

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
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        Vector3 input = new Vector3(-y, x, 0) * turnSpeed * Time.deltaTime;

        //Criação Quaternions
        Quaternion yaw = Quaternion.Euler(0, x, 0);
        Quaternion pitch = Quaternion.Euler(-y, 0, 0);


        //Translacao Input
        //Ordem de Aplicacao de Rotacao
        playerCamera.transform.rotation = yaw * playerCamera.transform.rotation * pitch;

    }

}