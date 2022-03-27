using UnityEngine;

public class CameraScript : MonoBehaviour
{
    /// <summary>
    /// The Player
    /// </summary>
    [SerializeField]
    private GameObject player;

    /// <summary>
    /// The lerp speed of the camera movement
    /// </summary>
    [SerializeField]
    private float lerpSpeed; // value = 3
    void Update()
    {
        if (player.transform.position != transform.position)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, lerpSpeed * Time.deltaTime);
        }
    }
}
