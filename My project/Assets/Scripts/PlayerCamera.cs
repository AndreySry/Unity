using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public float offsetX = 0;
    public float offsetZ = 5;
    public float playerVelocity = 5;
    private float movementX;
    private float movementZ;
   
   

    // Update is called once per frame
    void Update()
    {
        movementX = ((player.transform.position.x + offsetX - this.transform.position.x));
        movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z));
        this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), 0, (movementZ * playerVelocity * Time.deltaTime));
    }
}
