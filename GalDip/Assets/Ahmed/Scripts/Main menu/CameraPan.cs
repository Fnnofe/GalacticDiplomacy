using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 10f, 0f);
    [SerializeField] private bool usePingPong = false;
    [SerializeField] private float pingPongAngle = 10f;
    [SerializeField] private float pingPongSpeed = 1f;

    private float startAngle;

    void Start()
    {
        startAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        if (usePingPong)
        {
            float angle = Mathf.PingPong(Time.time * pingPongSpeed, pingPongAngle * 2) - pingPongAngle;
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, startAngle + angle, transform.eulerAngles.z);
        }
        else
        {
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
