using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
  
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    Vector3 targetPosition = new Vector3(player.transform.position.x + offset.x, transform.position.y, offset.z);
    transform.position = targetPosition;
        // transform.position = player.transform.position + offset;
    }
}
