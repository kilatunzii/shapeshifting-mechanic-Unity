using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapeShifter : MonoBehaviour
{
    //Create an array of gameobjects for shapes
    public GameObject[] shapes;
    public GameObject shapeShiftEffect;
    public float effectDuration = 2f;

    public int currentShapeIndex;


    // Start is called before the first frame update
    void Start()
    {
        //intialising the start shape once game is played
        currentShapeIndex = 0;
        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i].SetActive(false);
            if (i == currentShapeIndex)
                shapes[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shapeShift();
        }
    }

    void shapeShift()
    {
        shapes[currentShapeIndex].SetActive(false);

        //Increment shape index
        currentShapeIndex++;
        if (currentShapeIndex >= shapes.Length)
        {
            currentShapeIndex = 0;
        }
        shapes[currentShapeIndex].SetActive(true);
        //create and destroy visual effect of shattering
        GameObject effect = Instantiate(shapeShiftEffect, transform.position, Quaternion.identity);
        Destroy(effect, effectDuration);
    }
  
}
