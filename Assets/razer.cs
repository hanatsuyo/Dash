using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class razer : MonoBehaviour
{
    private Vector3 moveDirection;
    private bool isMovingRightUp = true;

    private void Start()
    {
        moveDirection = new Vector3(1, 0, 1).normalized;
    }

    private void Update()
    {
        float speed = 3.0f; // 移動速度

        // スペースキーが押されたら移動方向を切り替える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMovingRightUp = !isMovingRightUp;

            if (isMovingRightUp)
            {
                moveDirection = new Vector3(1, 0, 1).normalized;
            }
            else
            {
                moveDirection = new Vector3(1, 0, -1).normalized;
            }
        }

        // オブジェクトを移動
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}








