using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBendEffect : MonoBehaviour
{
    public GameObject player;
    Vector3 distanceFromPlayer;
    Vector3 originalPosition;
    WorldBendDriver worldBendDriver;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
        worldBendDriver= FindAnyObjectByType<WorldBendDriver>();
        originalPosition=transform.position;
    }



    void Update()
    {
        //--------Here1-----Negetive Space

        // Step 1: Calculate distance from player
        distanceFromPlayer = player.transform.position - transform.position;
        Vector3 temp= Vector3.one;
        temp = temp * worldBendDriver.startingDistance;
        distanceFromPlayer = distanceFromPlayer - temp;
        // Step 2: Check if we’re past the startingDistance on the Z axis
        float comparisonResult;
        Unity_Comparison_Less_float(0, distanceFromPlayer.z, out comparisonResult);

        // Step 3: Calculate rise target in Y axis (e.g., squared for dramatic effect)
        float riseAmount = Mathf.Pow(distanceFromPlayer.z* comparisonResult, 2) * worldBendDriver.bendStrength;
        float branch1False = riseAmount;

        Unity_Comparison_Less_float(0, distanceFromPlayer.x, out comparisonResult);
         riseAmount = Mathf.Pow(distanceFromPlayer.x * comparisonResult, 2) * worldBendDriver.bendStrength;


         float branch2False = riseAmount;
        //--------Here1-----Negetive Space


        //--------Here2-----

        distanceFromPlayer = player.transform.position - transform.position;

        temp = temp * worldBendDriver.startingDistance;
        distanceFromPlayer = distanceFromPlayer - temp;
        // Step 2: Check if we’re past the startingDistance on the Z axis
        Unity_Comparison_Greater_float(distanceFromPlayer.z, 0, out comparisonResult);

        // Step 3: Calculate rise target in Y axis (e.g., squared for dramatic effect)
         riseAmount = Mathf.Pow(distanceFromPlayer.z * comparisonResult, 2) * worldBendDriver.bendStrength;
        float branch1True = riseAmount;
        float branch1Predicate= comparisonResult;

        Unity_Comparison_Greater_float(distanceFromPlayer.x, 0, out comparisonResult);
        riseAmount = Mathf.Pow(distanceFromPlayer.x * comparisonResult, 2) * worldBendDriver.bendStrength;

        float branch2True = riseAmount;
        float branch2Predicate= comparisonResult;
        //--------Here2-----



        // Step 4: Branch between rising and not rising
        float newPosition, newPosition2, newPositionFinal;

        Unity_Branch_float(branch1Predicate, branch1True, branch1False, out newPosition);
        Unity_Branch_float(branch2Predicate, branch2True, branch2False, out newPosition2);
        newPositionFinal = newPosition + newPosition2;
        // Step 5: Apply the movement relative to original position
        transform.position = originalPosition + new Vector3(0, newPositionFinal , 0);
        Debug.Log("new position:  "+ newPositionFinal);
    }

    //Comparison Node  Greater
    void Unity_Comparison_Greater_float(float A, float B, out float Out)
    {
        Out = A > B ? 1f : 0f;
    }
    //Comparison Node  Less
    void Unity_Comparison_Less_float(float A, float B, out float Out)
    {
        Out = A < B ? 1f : 0f;
    }
    //Branch Node
    void Unity_Branch_float(float Predicate, float True, float False, out float Out)
    {
        Out = Mathf.Lerp(False, True, Predicate);
    }
}




