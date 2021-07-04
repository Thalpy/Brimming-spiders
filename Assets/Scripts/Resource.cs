using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    [SerializeField] private string resourceName;
    [SerializeField] private double weight;

    public string ResourceName { get => resourceName; set => resourceName = value; }

    public double Weight { get => weight; set => weight = value; }

    public Resource(string resourceName = "Test Resource", double weight = 1.0)
    {
        this.ResourceName = resourceName;
        this.Weight = weight;
    }

}
