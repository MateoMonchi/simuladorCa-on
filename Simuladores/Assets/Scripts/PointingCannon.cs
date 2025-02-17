using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointingCannon : MonoBehaviour
{
    private float rotationX;
    private float rotationY;

    public Slider verticalSlider;
    public Slider horizontalSlider;
    public Text verticaltext;
    public Text horizontaltext;


    private void Start()
    {
        horizontalSlider.minValue = -45f;
        horizontalSlider.maxValue = 45f;
        verticalSlider.minValue = -45f;
        verticalSlider.maxValue = 45f;
    }

    private void Update()
    {
        rotationX = verticalSlider.value;
        rotationY = horizontalSlider.value;

        this.transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        horizontaltext.text = rotationY.ToString("F2");
        verticaltext.text = rotationX.ToString("F2");
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
