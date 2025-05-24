using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(Vector3.up * 360, 1f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);

        transform.localScale = Vector3.zero;
        transform.DOScale(1, .5f).SetEase(Ease.OutBack);
    }
    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameDirector.instance.coinManager.CoinCollected();
            Destroy(gameObject);
        }
    }
}
