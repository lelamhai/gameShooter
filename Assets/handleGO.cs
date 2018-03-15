using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleGO : MonoBehaviour
{


    public GameObject Bakground;
    public GameObject Flay;
    public float speed;
    public GameObject bullet;
    List<GameObject> listBullet = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(bullet, bullet.transform.position, Quaternion.identity);
            listBullet.Add(go);
        }
    }

    // Use this for initialization
    void Start()
    {
        speed = 5f;

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var center = Bakground.GetComponent<Run>().listBackground[0].transform.position.x;
            var left = center - ((Bakground.GetComponent<Run>().ImageBG.rect.width) / 2) / 100;
            var right = center + ((Bakground.GetComponent<Run>().ImageBG.rect.width) / 2) / 100;

            if (Flay.transform.position.x > left)
            {
                Flay.transform.position = new Vector3(Flay.transform.position.x - speed * Time.deltaTime, Flay.transform.position.y, Flay.transform.position.z);
            }

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            var center = Bakground.GetComponent<Run>().listBackground[0].transform.position.x;
            var left = center - ((Bakground.GetComponent<Run>().ImageBG.rect.width) / 2) / 100;
            var right = center + ((Bakground.GetComponent<Run>().ImageBG.rect.width) / 2) / 100;

            if (Flay.transform.position.x < right)
            {
                Flay.transform.position = new Vector3(Flay.transform.position.x + speed * Time.deltaTime, Flay.transform.position.y, Flay.transform.position.z);
            }
        }

        Shoot();
    }



    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!listBullet[0].GetComponent<ControllerBullet>().shot)
            {
                listBullet[0].GetComponent<ControllerBullet>().Shooter();
            }
        }

    }
}
