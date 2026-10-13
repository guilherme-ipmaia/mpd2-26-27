using UnityEngine;
using DG.Tweening;

public class PlushPlayer : MonoBehaviour
{
    public Transform point;
    public float duration = 0.5f;
    public Ease ease;
    public AnimationCurve curve;
    void Start()
    {
        //transform.DOMove(point.position, duration).SetEase(curve).OnComplete(MoveComplete);
        //transform.DOMove(point.position, duration).SetEase(curve).SetLoops(-1, LoopType.Yoyo).OnStepComplete(MoveComplete);
    }

    //void MoveComplete()
    //{
    //    Camera.main.transform.DOShakePosition(0.2f, 0.4f, 80);
    //}

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            //transform.DOScale(0.8f, 0.05f).SetLoops(2,LoopType.Yoyo);
            transform.DOScale(0.8f, 0.1f).SetEase(curve);

            //Rotacao Grande
            //transform.DORotate(new Vector3(5000, 2000, 0), 2f, RotateMode.FastBeyond360);

            //Rotacao Pequena
            transform.DORotate(new Vector3(50, 50, 0), 0.1f, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad);
        }
    }


}
