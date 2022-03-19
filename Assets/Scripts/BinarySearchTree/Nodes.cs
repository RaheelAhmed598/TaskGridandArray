using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nodes : MonoBehaviour
{
    public int value;
    public Nodes parentNode;
    public Nodes lowNode;
    public Nodes highNode;
    public Transform tf;
    private Text textValue;
    public bool isRoot;
    public Vector3 rootPosition;

    // Start is called before the first frame update
    void Start()
    {
        textValue = GetComponent<Text>();
        textValue.text = value.ToString();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoot)
        {
            tf.position = rootPosition;
        }
        if (lowNode)
        {
            lowNode.tf.position = tf.position - tf.up * 15 - tf.right * 25;
        }
        if (highNode)
            highNode.tf.position = tf.position + tf.right * 25 - tf.up * 15;
    }
}
    

