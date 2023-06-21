using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DebugGolpes : MonoBehaviour
{
    public GameObject startPoint;
    public Vector3 HitPointDistance;
    public Color colorRasho;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startPoint == null)
        {
            startPoint = this.gameObject;
        }

        Vector3 realHitPoint = new Vector3(startPoint.transform.position.x + HitPointDistance.x, startPoint.transform.position.y, startPoint.transform.position.z);
        Debug.DrawRay(startPoint.transform.position, HitPointDistance, colorRasho);
    }
}
