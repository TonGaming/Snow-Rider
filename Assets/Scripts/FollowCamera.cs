using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float distanceToCam = 12f;
    [SerializeField] GameObject thingToFollow;
    private void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, distanceToCam);

    }
}
