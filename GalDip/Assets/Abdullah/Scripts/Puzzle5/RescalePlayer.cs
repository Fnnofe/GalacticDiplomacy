using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescalePlayer : MonoBehaviour
{
    bool startEffect;
    public float maxDistance = 10f;     
    public float minScale = 0.2f;       
    public float normalScale = 1f;
    public float miniSpeed= 0.1f;
    public float miniRunSpeed = 0.3f;

    public Transform player;
    private Transform targetTransform;
    private float playerSpeed;
    private float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = player;
        playerSpeed = player.GetComponent<PlayerMovement>().movementSpeed;
        runSpeed = player.GetComponent<PlayerMovement>().runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPlayer);

        if (dot < 0) // Player is behind
        {
            float distance = Vector3.Distance(transform.position, player.position);
            float t = Mathf.Clamp01(distance / maxDistance); // 0 = close, 1 = maxDistance or farther

            float scaleValue = Mathf.Lerp(normalScale, minScale, t);
            float speedScaleValue = Mathf.Lerp(normalScale, miniSpeed, t);
            float runScaleValue = Mathf.Lerp(normalScale, miniRunSpeed, t);

            targetTransform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            player.GetComponent<PlayerMovement>().movementSpeed=speedScaleValue;
            player.GetComponent<PlayerMovement>().runSpeed = runScaleValue;

        }
        else
        {
            // Restore to normal scale if in front
            targetTransform.localScale = Vector3.one * normalScale;
            player.GetComponent<PlayerMovement>().movementSpeed = playerSpeed;
            player.GetComponent<PlayerMovement>().runSpeed = runSpeed;

        }
    }


}
