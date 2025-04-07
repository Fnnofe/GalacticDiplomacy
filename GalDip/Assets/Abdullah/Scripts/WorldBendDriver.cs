using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WorldBendDriver : MonoBehaviour
{
    public float bendStrength=0.2f;
    public float startingDistance= 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Shader.SetGlobalFloat("_CurveStrength", bendStrength);
            Shader.SetGlobalFloat("_CurveStartPoint", startingDistance);



    }



}
