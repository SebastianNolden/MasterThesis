using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction = new Vector3(1, 0, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "DestroyWall") {
            Destroy(this.gameObject);
        }
    }
}
