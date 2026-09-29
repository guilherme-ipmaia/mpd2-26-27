using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler current;

    [Header("Input Actions")]
    public InputAction move;
    public InputAction look;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        move.Enable();
        look.Enable();
    }
}
