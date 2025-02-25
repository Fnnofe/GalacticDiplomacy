using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    int currentWaypoint = 0;
    private int currentTrackIndex;
    private List<List<GameObject>> tracks; 
    public float speed;
    [SerializeField] PlanetsTrack planetsTrack;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject fwdButton;
    void Start()
    {
        tracks = new List<List<GameObject>>()
        {
            planetsTrack.trackOne,
            planetsTrack.trackTwo,
            planetsTrack.trackThree,
        };
    }

    void Update()
    {
       MovePlayer();
    }

    public void MovePlayer()
    {
        if (tracks.Count == 0 || currentWaypoint >= tracks[currentTrackIndex].Count) return;
        Transform target = tracks[currentTrackIndex][currentWaypoint].transform;
        transform.LookAt(target.position);
        if (Vector3.Distance(transform.position, tracks[currentTrackIndex][currentWaypoint].transform.position) >= 0.1f)
        {
            transform.Translate(0,0, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(0,0, 0);
        }
        if(currentWaypoint == 0 && currentTrackIndex == 1 || currentWaypoint == 4 && currentTrackIndex == 1)
            backButton.SetActive(false);
        else
            backButton.SetActive(true);
        if(currentWaypoint == 3 && currentTrackIndex == 1 || currentWaypoint == 7 && currentTrackIndex == 1)
            fwdButton.SetActive(false);
        else
            fwdButton.SetActive(true);
    }

    public void MoveForward()
    {
        currentWaypoint++;
        if (currentWaypoint >= tracks[currentTrackIndex].Count)
        {
            currentWaypoint = 0;
        }
    }

    public void MoveBackwards()
    {
        currentWaypoint--;
        if (currentWaypoint < 0)
        {
            currentWaypoint = tracks[currentTrackIndex].Count - 1;
        }
    }

    public void MoveNextTrack()
    {
        if (currentTrackIndex == 0)
        {
            if (currentWaypoint == 9)
            {
                currentTrackIndex = 1;
                currentWaypoint = 0;
            }
            if (currentWaypoint == 14)
            {
                currentTrackIndex = 1;
                currentWaypoint = 7;
            }
        }
        else if (currentTrackIndex == 1)
        {
            if (currentWaypoint == 0)
            {
                currentTrackIndex = 0;
                currentWaypoint = 9;
            }
            if (currentWaypoint == 7)
            {
                currentTrackIndex = 0;
                currentWaypoint = 14;
            }
            if (currentWaypoint == 3)
            {
                currentTrackIndex = 2;
                currentWaypoint = 25;
            }
            if (currentWaypoint == 4)
            {
                currentTrackIndex = 2;
                currentWaypoint = 20;
            }
        }
        else if (currentTrackIndex == 2)
        {
            if (currentWaypoint == 25)
            {
                currentTrackIndex = 1;
                currentWaypoint = 3;
            }
            if (currentWaypoint == 20)
            {
                currentTrackIndex = 1;
                currentWaypoint = 4;
            }
        }
       
    }
}
