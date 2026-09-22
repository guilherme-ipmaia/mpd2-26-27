using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 0.2f;
    Vector3 rotation;

    private void Start()
    {
        //Definir Temporariamente cursor
        Cursor.lockState= CursorLockMode.Confined;
        Cursor.visible = false;

        //Iniciar valor default rotacao
        rotation = transform.eulerAngles;
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
        Vector3 input = new Vector3(x, 0, y);

        //Translacao Input
        Vector3 worldInput = transform.TransformDirection(input);

        //Movimento
        transform.position += worldInput * moveSpeed * Time.deltaTime;
    }

    void Turn()
    {
        Vector3 mouse = Input.mousePositionDelta;
        rotation.x -= mouse.y * turnSpeed;
        rotation.y += mouse.x * turnSpeed;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
