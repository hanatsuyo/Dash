using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flow : MonoBehaviour
{
    public float pushForce = 10.0f; // 吹き飛ばす力

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            Vector3 pushDirection = (collision.transform.position - transform.position).normalized;
            otherRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
