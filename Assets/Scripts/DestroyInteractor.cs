using UnityEngine;

public class DestroyInteractor : Interactor
{
    public override void Interact()
    {
        GameObject.Destroy(gameObject);
    }
}
