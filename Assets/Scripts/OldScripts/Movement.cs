using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void TargetSeen()
    {
       gameObject.transform.position -= gameObject.transform.right/1.5f;
    }
}
