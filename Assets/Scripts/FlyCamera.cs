using UnityEngine;
using UnityEngine.InputSystem;

public class FlyCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 0.2f;

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
        Vector3 input = new Vector3(x, 0, y);

        //Translacao Input
        Vector3 worldInput = transform.TransformDirection(input);

        //Movimento
        transform.position += worldInput * moveSpeed * Time.deltaTime;
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
        transform.rotation = yaw * transform.rotation * pitch;

    }

}