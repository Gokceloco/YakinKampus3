using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform objectToFollow;

    private void Update()
    {
        transform.position = objectToFollow.position;
    }
}