using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{

    public GameObject Player;
    public float timeOffset;
    public Vector2 posOffset;

    private Vector3 velocity;
    
    public float leftLimit = -1.08f;
    public float rightLimit = .02f;
    public float topLimit = 1.02f;
    public float bottomLimit = -32.98f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //camera current position
        
        Vector3 startPos = transform.position;

        //Player current position

        Vector3 endPos = Player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -100;


        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit),new Vector2 (rightLimit,topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));


    }


}
