using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEfector : MonoBehaviour
{
    public float minRotation;
    public float maxRotation;

    public float time = 0.7f;

    public RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = new Vector3(rect.rotation.x, rect.rotation.y, Random.Range(minRotation,maxRotation));
        rect.eulerAngles = angles;
        Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
