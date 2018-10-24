using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GA.Fitness_Functions
{
    public class MyFitness999 : IFitnessFunction
    {
        //Should be beteween 0..1
        public float DetermineFitness(CarState state)
        {

            //Debug.Log(state.DistanceFromGoal() + " -- " + state.AngleToGoal());
            int maxDistance = 40;

            float angle = state.AngleToGoal(); //transform:  angle = 1 --> Optimal; angle = 0 --> so bad
            float distance = state.DistanceFromGoal();

            float weightDistance = 0.50f;
            float weightAngle = 0.30f;
            float weightCollision = 0.1f;
            float weightSpeed = 0.1f;

            // 0 ... car ... max    --> lerp
            Debug.Log("the angle is: " + angle);
            float partDistance  = weightDistance    * (float) Math.Pow((1f - Math.Min(distance, maxDistance) / maxDistance) ,2);
            float partCollision = weightCollision   * (float) Math.Pow((1f - Math.Min(state.NumberOfCollisions(), 4) / 4)   ,2);
            float partSpeed     = weightSpeed       * (float) Math.Pow((1f - Math.Min(state.CurrentVelocity(), 1))          ,2);
            float partAngle     = weightAngle       * (float) Math.Pow((1f - (Math.Abs(angle / 4)))                         ,2); // why
            //float partAngle = weightAngle           * ((float)Math.Pow(1f - Math.Min(angle, (4 - angle)) / 2f, 2f));
            //float partAngle = weightAngle           * (float)Math.Pow((1 - (Math.Abs ( 2 - angle) / 2)),1f);
            //Debug.Log("Angle: " + angle + "  rel: " + relAngle + " with faktor:" + partAngle);

            float sum = partDistance + partAngle + partCollision + partSpeed;
            return sum;
            //else return sum;
        }
    }
}
