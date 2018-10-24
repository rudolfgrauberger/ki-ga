using Assets.Scripts.GA.Fitness_Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GA.Recombiners
{
    class NPointCrossOver : IRecombiner
    {
        //MyFitnessFunction fitnessFunction = new MyFitnessFunction();
        public string Combine(string parentA, string parentB)
        {
            int n = (parentA.Length / 2);
            int N = parentA.Length -1;

            //01234567-- > 8;

            String partA = parentA.Substring(0, n);
            String partB = parentB.Substring(n, n);

            String child = String.Concat(partA, partB);
            return child;
        }
    }
}
