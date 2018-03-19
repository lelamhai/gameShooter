using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleGO : MonoBehaviour
{
    public GameObject Bakground;
    public GameObject Flay;
    public float speed;
    public GameObject bullet;
    public List<GameObject> listBullet = new List<GameObject>();

    private void Awake()
    {
        GameVariables.InstanceH.Bullet = -1;
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(bullet, bullet.transform.position, Quaternion.identity);
            go.AddComponent<BoxCollider2D>();
            go.AddComponent<Rigidbody2D>();
            listBullet.Add(go);
        }
    }

    // Use this for initialization
    void Start()
    {
        speed = 5f;
        GameVariables.InstanceH.coundBullet = listBullet.Count;
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
        UpdateBullet();
        Shoot();
    }


    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = StartCoroutine(coroutineA());
        }

    }
    public void UpdateBullet()
    {
        for (int i = listBullet.Count-1; i >= 0; i--)
        {
            if (!listBullet[i].GetComponent<ControllerBullet>().shot)
            {
                GameVariables.InstanceH.Bullet = i;
            }
        }
    }
    Coroutine start;
    IEnumerator coroutineA()
    {
        GameVariables.InstanceH.Bullet++;
        yield return new WaitForSeconds(0.1f);
      
        if (!listBullet[GameVariables.InstanceH.Bullet].GetComponent<ControllerBullet>().shot)
        {
            listBullet[GameVariables.InstanceH.Bullet].GetComponent<ControllerBullet>().Shooter();
        }
    }


}
