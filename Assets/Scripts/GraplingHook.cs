using System.Collections;
using UnityEngine;

public class GraplingHook : MonoBehaviour
{
    public float distance = 10f;
    public float maxDistance;
    public float decreaseStep;
    public float increaseStep;
    public LayerMask mask;
    public LineRenderer line;

    public bool isRoping;

    private DistanceJoint2D joint;
    private PlayerController playerC;
    private Vector3 targetPos;
    private RaycastHit2D hit;

    private void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        joint.enabled = false;
        line.enabled = false;
    }

    private void Update()
    {
        if (!playerC.isResetting)
        {
            Rope();
        }
    }

    private void Rope()
    {
        //Decrease the rope lenght
        if (Input.GetKey(KeyCode.LeftShift) && joint.distance > 1f)
        {
            joint.distance -= decreaseStep;
        }
        //Increase the rope lenght
        if (Input.GetKey(KeyCode.LeftControl) && joint.distance < maxDistance)
        {
            joint.distance += increaseStep;
        }

        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }

            isRoping = true;
        }

        if (Input.GetMouseButton(0))
        {
            line.SetPosition(0, transform.position);
        }
        if (Input.GetMouseButtonUp(0))
        {
            ResetHook();

            isRoping = false;
        }
    }

    public void ResetHook()
    {
        joint.enabled = false;
        line.enabled = false;
    }
}