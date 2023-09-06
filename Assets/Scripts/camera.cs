using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    public float verticalOffsetThreshold = 2.0f; // プレイヤーが画面の半分以上進む閾値
    public float cameraLerpSpeed = 5.0f; // カメラの移動スピード

  
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

        float verticalOffset = player.transform.position.y - transform.position.y;
        if (verticalOffset > verticalOffsetThreshold)
        {
            // 画面上部二割よりも上に行った時には超過分上にカメラを移動
            targetPosition.y += verticalOffset - verticalOffsetThreshold;
        }
        else if (verticalOffset < -verticalOffsetThreshold)
        {
            // 画面下部二割よりも下に行った時には超過分下にカメラを移動
            targetPosition.y += verticalOffset + verticalOffsetThreshold;
        }

        // カメラ位置をX軸方向に追従しつつ滑らかに変更
        // targetPosition.x = player.transform.position.x; // X座標をプレイヤーのX座標に合わせる
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraLerpSpeed * Time.deltaTime);
    }
  }
