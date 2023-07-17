using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVelocity : MonoBehaviour
{
    Vector3 handVelocity;
    Vector3 positionLastFrame;

    // Start is called before the first frame update
    void Start()
    {
        handVelocity = Vector3.zero;
        positionLastFrame = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (positionLastFrame != transform.position) {
            handVelocity = transform.position - positionLastFrame;
            handVelocity /= Time.deltaTime;
        }

        positionLastFrame = transform.position;
    }

    public float GetHandVelocity() {
        return handVelocity.magnitude;
    }
}
