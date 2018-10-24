using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTerminator999 : ITerminator
{
    private float abbruchbedingung = 1;


    public bool JudgementDay(GenerationDB.Generation generation)
    {


        if(generation.Fittest.fitnessValue > 0.95){
            return true;
        } else {
            return false;
        }

//        throw new NotImplementedException();
    }
}
