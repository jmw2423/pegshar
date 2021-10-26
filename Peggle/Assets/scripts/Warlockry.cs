using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warlockry : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject warlockBucket;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // StartCoroutine(Warlockry());
        }
    }
    //IEnumerator Warlockry()
    //{
    //    Instantiate(warlockBucket, new Vector3(2.0f,), Quaternion.identity);
    //}
}
