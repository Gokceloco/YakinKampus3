using UnityEngine;

public class FXManager : MonoBehaviour
{
    public ParticleSystem bulletImpactPSPrefab;

    public void PlayBulletImpactPS(Vector3 pos, Vector3 dir, Color color)
    {
        var newPS = Instantiate(bulletImpactPSPrefab);
        newPS.transform.position = pos;
        newPS.transform.LookAt(pos - dir);
        var main = newPS.main;
        main.startColor = color;
        newPS.Play();
    }
}
