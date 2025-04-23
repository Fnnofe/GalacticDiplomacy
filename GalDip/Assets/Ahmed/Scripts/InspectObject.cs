using TMPro;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    private float rotationSpeed = 50f;
    private Vector3 previousMousePosition;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform inspPoint;
    public bool shouldRestore = false;

    private bool inspectStarted = false;
    public float zoomSpeed = 0.2f;
    public float minDistance=0.1f;
    float maxDistance=1f;

    public GameObject controlUI;
    private void Start()
    {
        inspPoint = Camera.main.transform.GetChild(0);


        

        if (controlUI == null)
        {

            Debug.LogError("UIControls GameObject not found in the scene!");
            controlUI = GameObject.Find("UIControls");

        }


    }

    void Update()
    {


        if (shouldRestore)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            this.controlUI.SetActive(false);

            Destroy(this);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
        }


        //spin around
        if (Input.GetKey(KeyCode.LeftShift) & Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            float rotationX = -mouseDelta.y * rotationSpeed * Time.deltaTime;
            float rotationY = -mouseDelta.x * rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(rotationY, 0, 0);
            transform.rotation = rotation * transform.rotation;

            previousMousePosition = Input.mousePosition;

        }

        //spin front and sides
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            float rotationX = -mouseDelta.y * rotationSpeed * Time.deltaTime;
            float rotationY = -mouseDelta.x * rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0, rotationY, rotationX);
            transform.rotation = rotation * transform.rotation;

            previousMousePosition = Input.mousePosition;

        }

        //zoom 
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 comparePos = transform.position;
        transform.position += Camera.main.transform.forward * scroll * zoomSpeed;
        //zoom limit
        if ((Camera.main.transform.position - transform.position).magnitude < minDistance)
        {

            transform.position = comparePos;

        }
        else if ((Camera.main.transform.position - transform.position).magnitude > maxDistance)
        {
            transform.position = comparePos;
        }


        if (!inspectStarted)
        {
            transform.LookAt(Camera.main.transform);
            inspectStarted = true;
            this.controlUI.SetActive(true);

        }

        if (Input.GetMouseButtonDown(1))
        {
            shouldRestore = true;
            this.controlUI.SetActive(false);
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