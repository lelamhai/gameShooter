using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

    public SpriteRenderer[] listBackground;
    public float speed;
    public Transform start;
    public Transform end;
    public Vector3 start1;
    Vector3 end2;
    public Sprite ImageBG;

    private float tru;
    // Use this for initialization
    void Start () {
        speed = 5;
        start1 = new Vector3(start.position.x, start.transform.position.y + (ImageBG.rect.height/2)/100, start.position.z);
        end2 = new Vector3(end.position.x, end.transform.position.y - (ImageBG.rect.height / 2)/100, start.position.z);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        RunBackground();
    }

    private void RunBackground()
    {
        for (int i = 0; i < listBackground.Length; i++)
        {
            listBackground[i].transform.position = new Vector3(listBackground[i].transform.position.x, listBackground[i].transform.position.y - speed * Time.fixedDeltaTime, listBackground[i].transform.position.z);
            float speed1 = (speed * Time.fixedDeltaTime) * listBackground.Length;
            if (listBackground[i].transform.position.y <= end2.y)
            {
                tru = (end2.y - listBackground[i].transform.position.y);
                listBackground[i].transform.position = new Vector3(listBackground[i].transform.position.x, start1.y - (tru + speed1), listBackground[i].transform.position.z);
            }
        }
    }
}
