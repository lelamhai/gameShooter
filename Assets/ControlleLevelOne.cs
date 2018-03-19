using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlleLevelOne : MonoBehaviour {
    public Sprite[] listLv1;
    public GameObject Enemy1;
    public List<GameObject> listEnemy1 = new List<GameObject>(); 
    public handleGO mainControll;
    private Vector3 ct;

    private float localtionEnemy;
    // Use this for initialization
    void Start () {
        localtionEnemy = -1;
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(Enemy1, Enemy1.transform.position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            go.GetComponent<SpriteRenderer>().sprite = listLv1[0];
            go.AddComponent<BoxCollider2D>();
            go.AddComponent<Rigidbody2D>();
            go.transform.rotation = Quaternion.Euler(go.transform.rotation.x, go.transform.rotation.y, go.transform.rotation.z+ 180);
            listEnemy1.Add(go);
        }

        ct = mainControll.Flay.transform.position;
        getThreePlayEnemy();


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void getThreePlayEnemy()
    {
        for (int i = 0; i < 3; i++)
        {
            listEnemy1[i].transform.position = new Vector3(ct.x+localtionEnemy, ct.y+5, ct.z);
            localtionEnemy += 1;
        }
    }

}
