using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTerminator999 : ITerminator
{
    public bool JudgementDay(GenerationDB.Generation generation)
    {
        if(generation.Fittest.fitnessValue > 0.97){
            return true;
        } else {
            return false;
        }
    }
}
