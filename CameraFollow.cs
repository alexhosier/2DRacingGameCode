using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform toFollow;

    // Update is called once per frame
    void Update()
    {
        //toFollow.Translate(toFollow.position * Time.deltaTime);
        transform.position = new Vector3(toFollow.position.x, toFollow.position.y, toFollow.position.z - 20);
    }
}
