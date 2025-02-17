using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject spawnobject;
    public float speed;
    public Text speedtext;
    public Slider speedslider;
    public float mass;
    public Text masstext;
    public Slider massslider;

    public void Start()
    {
        speedslider.minValue = 0;
        speedslider.maxValue = 100;
        massslider.minValue = 1f;
        massslider.maxValue = 100;
    }
    public void Update()
    {
        speed = speedslider.value;
        mass = massslider.value;
        speedtext.text = speed.ToString("F2");
        masstext.text = mass.ToString("F2");
        if (Input.GetKeyDown(KeyCode.Space))
        {
           var bullet = Instantiate(spawnobject, spawnpoint.position, spawnpoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = spawnpoint.transform.right * speed;
            bullet.GetComponent<Rigidbody>().mass = mass;
        }
    }
}
