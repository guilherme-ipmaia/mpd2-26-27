using DG.Tweening;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).DOLocalRotate(Vector3.up * 360f, 0.9f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutQuad).SetLoops(-1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null) return;
        if (other.attachedRigidbody.tag != "Player") return;


        GameManager.current.CoinCollected();

        transform.DOScale(0f, 0.15f).SetEase(Ease.InBack, 4f).OnComplete(Kill);
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
