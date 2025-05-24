using DG.Tweening;
using System;
using UnityEngine;

public class Serum : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveY(transform.position.y + 1, .5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected();
        }
    }

    private void Collected()
    {
        GameDirector.instance.LevelCompleted();
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
