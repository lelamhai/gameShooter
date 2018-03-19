using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBullet : MonoBehaviour
{
    public handleGO r;

    private float speed = 2;
    public bool shot;
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (shot)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            stopBullet();
        }
    }
    public void Shooter()
    {
        var flayPosition = r.Flay.GetComponent<Transform>().position;
        transform.position = flayPosition;
        shot = true;
    }
    void stopBullet()
    {
        Vector3 start = r.Bakground.GetComponent<Run>().start1;
        if (transform.position.y > start.y)
        {
            transform.position = startPos;
            shot = false;
            GameVariables.InstanceH.Bullet--;

        }
    }



}
