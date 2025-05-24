using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(Vector3.up * 360, 1f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
    private void OnDestroy()
    {
        transform.DOKill();
    }
}
