using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BinarySearchTree : MonoBehaviour
{
    public Nodes root;
    public Nodes nodePrefab;
    private Nodes currentNode;
    public InputField inputBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddNode(Random.Range(0, 99));
        }
    }

    public void AddNode(int valueToAdd)
    {
        valueToAdd = int.Parse(inputBox.text);
        Nodes newNode = Instantiate(nodePrefab);
        newNode.transform.SetParent(GameObject.Find("Canvas").transform);
        newNode.value = valueToAdd;
        bool nodeAdded = false;
        if (!root)
        {
            root = newNode;
            newNode.isRoot = true;
        }
        else
        {
            currentNode = root;
            while (!nodeAdded)
            {
                if (newNode.value > currentNode.value)
                {
                    if (currentNode.highNode)
                    {
                        currentNode = currentNode.highNode;
                    }
                    else
                    {
                        currentNode.highNode = newNode;
                        newNode.parentNode = currentNode;
                        nodeAdded = true;
                    }
                }
                else if (newNode.value < currentNode.value)
                {
                    if (currentNode.lowNode)
                    {
                        currentNode = currentNode.lowNode;
                    }
                    else
                    {
                        currentNode.lowNode = newNode;
                        newNode.parentNode = currentNode;
                        nodeAdded = true;
                    }
                }
                else
                {
                    nodeAdded = true;
                    Destroy(newNode.gameObject);
                }
            }
        }
    }

    public Nodes FindNode(int valueToFind)
    {
        valueToFind = int.Parse(inputBox.text);
        if (root)
        {
            currentNode = root;
            if (valueToFind == root.value)
            {
                return root;
            }
            while (currentNode.value != valueToFind)
            {
                if (valueToFind < currentNode.value)
                {
                    if (currentNode.lowNode)
                    {
                        currentNode = currentNode.lowNode;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (valueToFind > currentNode.value)
                {
                    if (currentNode.highNode)
                    {
                        currentNode = currentNode.highNode;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (currentNode.value == valueToFind)
            {
                return currentNode;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public void RemoveNode(int valueToRemove)
    {
        valueToRemove = int.Parse(inputBox.text);
        Nodes nodeToRemove = FindNode(valueToRemove);
        bool removingHigh;

        if (nodeToRemove)
        {
           
            if (nodeToRemove == nodeToRemove.parentNode.lowNode)
            {
                removingHigh = false;
            }
            else
            {
                removingHigh = true;
            }


            if (removingHigh)
            {
                if (nodeToRemove.lowNode && !nodeToRemove.highNode)
                {
                    nodeToRemove.parentNode.highNode = nodeToRemove.lowNode;
                    nodeToRemove.lowNode.parentNode = nodeToRemove.parentNode;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }


                else if (nodeToRemove.highNode && !nodeToRemove.lowNode)
                {
                    nodeToRemove.parentNode.highNode = nodeToRemove.highNode;
                    nodeToRemove.highNode.parentNode = nodeToRemove.parentNode;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }


                else if (nodeToRemove.lowNode && nodeToRemove.highNode)
                {
                    nodeToRemove.lowNode.highNode = nodeToRemove.highNode;
                    nodeToRemove.parentNode.highNode = nodeToRemove.lowNode;
                    nodeToRemove.parentNode.highNode.parentNode = nodeToRemove.parentNode;
                    nodeToRemove.parentNode.highNode.highNode.parentNode = nodeToRemove.parentNode.highNode;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }


                else if (!nodeToRemove.lowNode && !nodeToRemove.highNode)
                {
                    nodeToRemove.parentNode.highNode = null;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }
            }



            else
            {
                if (nodeToRemove.lowNode && !nodeToRemove.highNode)
                {
                    nodeToRemove.parentNode.lowNode = nodeToRemove.lowNode;
                    nodeToRemove.lowNode.parentNode = nodeToRemove.parentNode;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }


                else if (nodeToRemove.highNode && !nodeToRemove.lowNode)
                {
                    nodeToRemove.parentNode.lowNode = nodeToRemove.highNode;
                    nodeToRemove.highNode.parentNode = nodeToRemove.parentNode;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }


                else if (nodeToRemove.lowNode && nodeToRemove.highNode)
                {
                    nodeToRemove.lowNode.highNode = nodeToRemove.highNode;
                    nodeToRemove.parentNode.lowNode = nodeToRemove.lowNode;
                    nodeToRemove.parentNode.lowNode.parentNode = nodeToRemove.parentNode;
                    nodeToRemove.parentNode.lowNode.highNode.parentNode = nodeToRemove.parentNode.highNode;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }

                else if (!nodeToRemove.lowNode && !nodeToRemove.highNode)
                {
                    nodeToRemove.parentNode.lowNode = null;
                    Destroy(nodeToRemove.gameObject);
                    return;
                }
            }
        }
    }
}

