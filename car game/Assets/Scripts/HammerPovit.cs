using UnityEngine;

public class Hammer360 : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
