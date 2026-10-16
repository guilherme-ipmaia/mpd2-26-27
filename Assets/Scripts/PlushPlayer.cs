using UnityEngine;
using DG.Tweening;

public class PlushPlayer : MonoBehaviour
{
    [Header("Push")]
    public float pushForce = 2f;
    public Transform arrow;
    public float rotationSpeed = 120f;


    [Header("Animations")]
    public Transform visualRoot;
    public float duration = 0.5f;
    public Ease ease;
    public AnimationCurve curve;
    private Tween shakeTween;

    private Rigidbody body;
    private Vector3 dir;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Start()
    {
    }

    //void MoveComplete()
    //{
    //    Camera.main.transform.DOShakePosition(0.2f, 0.4f, 80);
    //}

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (dir == Vector3.zero)
            dir = Random.insideUnitSphere;

            if (shakeTween != null)
            {
                shakeTween.Kill();
                shakeTween = null;
            }

            shakeTween = visualRoot.DOShakePosition(200f, 0.05f, 80);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            var intensity = rotationSpeed * Time.deltaTime;
            dir = Quaternion.Euler(intensity, intensity, intensity) * dir;
            arrow.right = -dir;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (shakeTween != null)
            {
                shakeTween.Kill();
                shakeTween = null;
            }

            //Limpar outras forças
            body.linearVelocity = Vector3.zero;

            //Aplicar força Random
            arrow.right = -dir;
            body.AddForce(dir * pushForce, ForceMode.Impulse);

            //Animacao
            visualRoot.DOScale(0.12f, 0.1f).SetEase(curve);
            visualRoot.DORotate(new Vector3(50, 50, 0), 0.1f, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad);
        }

        //if (Input.anyKeyDown)
        //{
        //    //transform.DOScale(0.8f, 0.05f).SetLoops(2,LoopType.Yoyo);


        //    //Rotacao Grande
        //    //transform.DORotate(new Vector3(5000, 2000, 0), 2f, RotateMode.FastBeyond360);

        //    //Rotacao Pequena

        //}
    }


}
