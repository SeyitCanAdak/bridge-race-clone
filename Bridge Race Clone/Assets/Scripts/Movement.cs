using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public Camera cam;
    Animator anim;
    public LayerMask layer;
    public float turnSpeed, speed,lerpValue;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity, layer))
        {
            Vector3 hitVec = hit.point;
            hitVec.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, hitVec, lerpValue), Time.deltaTime * speed);
            Vector3 newMovePoint = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newMovePoint - transform.position), Time.deltaTime * turnSpeed);
            if(!anim.GetBool("isRunning"))
            {
                anim.SetBool("isRunning", true);
            }
        }
    }
}

