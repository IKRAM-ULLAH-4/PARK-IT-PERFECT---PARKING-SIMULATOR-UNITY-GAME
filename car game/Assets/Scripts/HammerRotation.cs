using UnityEngine;

public class HammerRotate : MonoBehaviour
{
    public float speed = 80f;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
