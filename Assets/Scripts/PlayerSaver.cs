using UnityEngine;

public class Saver : MonoBehaviour
{
    public float teleportThreshold = -10f;
    public Vector3 teleportPosition = new Vector3(-10f, 2f, -10f);

    void Update()
    {
        
        if (transform.position.y < teleportThreshold)
        {
            
            transform.position = teleportPosition;
        }
    }
}
