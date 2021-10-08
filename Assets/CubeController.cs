using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float speed = -12; //Cubeの移動速度
    private float deadLine = -10; //消滅位置

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (this.speed * Time.deltaTime, 0, 0);

        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool isUnityChan = (collision.gameObject.name == "UnityChan2D")? true : false;
        if (isUnityChan == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
