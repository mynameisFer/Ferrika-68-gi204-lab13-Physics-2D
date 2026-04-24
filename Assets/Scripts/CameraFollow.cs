using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetX = 0f;

    void LateUpdate()
    {
        if (player != null)
        {

            Vector3 newPos = transform.position;


            newPos.x = player.position.x + offsetX;


            transform.position = newPos;
        }
    }
}