using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// test 123
/// </summary>
public class DummyFitness : IFitnessFunction
{

    public float DetermineFitness(CarState state)
    {
        return UnityEngine.Random.value * 1000;
    }
}
