using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainCamera_Action : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0f;
    public float offsetY = 0.1f;
    public float offsetZ = -1f;

    Vector3 cameraPosition;

    private void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = cameraPosition;
       
    }
}
