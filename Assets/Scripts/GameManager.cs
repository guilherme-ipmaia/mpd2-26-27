using DG.Tweening;
using System.Collections;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public int coinsToCollect = 4;
    public int coinsCollected = 0;

    [Header("UI")]
    public CanvasGroup container;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        current = this;

        coinsCollected = 0;
        UpdateCoinsText();
    }

    IEnumerator Start()
    {
        container.alpha = 1;
        int maxTime = 3;
        for (int i = 0; i < maxTime; i++)
        {
            countdownText.text = (maxTime - i).ToString();
            countdownText.transform.DOScale(9f, 0.3f).From(12f).SetEase(Ease.InOutBack);
            yield return new WaitForSeconds(1f);
        }
        container.DOFade(0, 0.2f);

    }


    public void CoinCollected()
    {
        coinsCollected++;
        UpdateCoinsText();

        if (coinsCollected == coinsToCollect)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    void UpdateCoinsText()
    {
        coinsText.text = $"{coinsCollected}/{coinsToCollect}";
    }
}
