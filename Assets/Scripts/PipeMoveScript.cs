using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private float deadZone = -50f;

    void Update()
    {
        if(BirdScript.isBirdAlive)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
