using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Camera playerCamera;
    public float distance = 5f;
    public LayerMask layerMask = ~1;

    bool hasHit, hasInteractor;
    Interactor interactor;

    void Update()
    {
        Hover();

        if (InputHandler.current.interact.WasPressedThisFrame())
        {
            Interact();
        }
    }

    void Hover()
    {
        hasHit = Physics.Raycast(
                   playerCamera.transform.position,
                   playerCamera.transform.forward,
                   out RaycastHit hitinfo, distance, layerMask);

        ///Debug
        Debug.DrawLine(playerCamera.transform.position,
          playerCamera.transform.position + playerCamera.transform.forward * distance,
          hasHit ? Color.green : Color.red);

        if (!hasHit) return;
        hasInteractor = hitinfo.transform.TryGetComponent<Interactor>(out interactor);
    }

    void Interact()
    {
        if (!hasHit) return;
        if (!hasInteractor) return;

        interactor.Interact();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (hasHit && hasInteractor)
            Gizmos.color = Color.green;

        Gizmos.DrawSphere(playerCamera.transform.position + playerCamera.transform.forward * distance, 0.3f);
    }
}
