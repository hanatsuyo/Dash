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
        transform.position = player.transform.position + offset;
    }
}
