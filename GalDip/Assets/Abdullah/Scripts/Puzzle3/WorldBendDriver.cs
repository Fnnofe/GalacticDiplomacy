using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode]
public class WorldBendDriver : MonoBehaviour
{
    public static float bendStrength { get; set; } = 0.2f;
    public static float startingDistance { get; set; } = 7f;
    public float maxBend = 0.20f;
    public float maxDistant = 7f;
    public float lerpTimer = startingDistance = 0;

    public float currentBend = 0.00f;
    public float currenStartingDistance = 0.00f;
    public static int countLoops;

    public UnityEvent SpawnSecretArtifact;

    int reveresed = 1;

    // Start is called before the first frame update
    void Awake()
    {
        bendStrength = maxBend;
        startingDistance = maxDistant;

    }
    void Start()
    {
        bendStrength = 0;
        startingDistance = 0;
        Shader.SetGlobalFloat("_CurveStrength", 0);
        Shader.SetGlobalFloat("_CurveStartPoint", 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (currentBend != bendStrength || currenStartingDistance != startingDistance)
        {

            currentBend = Mathf.Lerp(currentBend, bendStrength, lerpTimer);
            currenStartingDistance = Mathf.Lerp(currenStartingDistance, startingDistance, lerpTimer);

            Shader.SetGlobalFloat("_CurveStrength", currentBend);
            Shader.SetGlobalFloat("_CurveStartPoint", currenStartingDistance);
        }

    }
    public void AffectWorld(bool isReversed)
    {
        countLoops += isReversed ? -1 : 1;
        countLoops = Mathf.Clamp(countLoops, -3, 3);

        Debug.Log("countLoops= " + countLoops);

        float abs = Mathf.Abs(countLoops);
        float dir = Mathf.Sign(countLoops);

        bendStrength = dir * maxBend * (abs == 0 ? 0f : abs == 1 ? 0.33f : abs == 2 ? 0.66f : 1f);
        startingDistance = (abs == 0 ? 1 : reveresed) * maxDistant * (abs == 3 ? 0.55f : abs == 2 ? 0.66f : 1f);

        if (abs == 3)
            SpawnSecretArtifact.Invoke();

        Debug.Log("startingDistance:  " + startingDistance);
        Debug.Log("Curve:  " + bendStrength);
        Debug.Log("-----------------------");
    }

    public void ArtfactPickedUp()
    {

        countLoops = 1;
        AffectWorld(true);


    }

}
