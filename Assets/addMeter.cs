using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceDisplayTMP : MonoBehaviour
{
    public Transform objectToTrack;
    public TextMeshProUGUI distanceText;

    private float totalDistance;
    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = objectToTrack.position;
    }

    private void Update()
    {
        float distanceMoved = Vector3.Distance(lastPosition, objectToTrack.position);
        totalDistance += distanceMoved;
        lastPosition = objectToTrack.position;

        distanceText.text =  totalDistance.ToString("F2") + " m";
    }
}
