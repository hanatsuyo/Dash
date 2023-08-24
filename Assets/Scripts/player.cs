using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
  private float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    Vector3 movement = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    transform.Translate(movement);
    }
}
