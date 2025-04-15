using UnityEngine;

public class InspectObject : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private Vector3 previousMousePosition;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform inspPoint;
    public bool inspecting = false;

    private bool shouldRestore = false;

    private void Start()
    {
        inspPoint = Camera.main.transform.GetChild(0);
    }

    void Update()
    {
        if (shouldRestore)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            Destroy(this);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            float rotationX = mouseDelta.y * rotationSpeed * Time.deltaTime;
            float rotationY = -mouseDelta.x * rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            transform.rotation = rotation * transform.rotation;

            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(1))
        {
            shouldRestore = true;
        }
    }

    public void ObjectCloseUp()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        inspPoint = Camera.main.transform.GetChild(0);
        transform.position = inspPoint.position;
    }
}