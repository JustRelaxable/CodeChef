using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public GameObject chef;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void TargetSeen()
    {
        Debug.Log("walk kartı görüşe girdi");
        //Debug.Log(chef.transform.position);
        chef.transform.rotation *= Quaternion.Euler(0, 90, 0);
    }

    public void TargerLost()
    {
        Debug.Log("görüşten çıktı");
        //Debug.Log(chef.transform.position);
    }
}
