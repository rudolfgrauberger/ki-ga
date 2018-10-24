﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamD_GelbFitness : IFitnessFunction
{
    const int WEIGHT_ANGLE = 30;
    const int WEIGHT_VELOCITY = 25;
    const int WEIGHT_DISTANCE = 100;
    const int WEIGHT_COLLISION = 200;

    public float DetermineFitness(CarState state)
    {
        var angle = state.AngleToGoal();
        var velocity = state.CurrentVelocity();
        var distance = state.DistanceFromGoal();
        var collisions = state.NumberOfCollisions();

        var goalTransform = GameObject.Find("GoalPosition").transform;
        var spawnPoint = GameObject.Find("SpawnPoint").transform;

        var relAngle = angle * WEIGHT_ANGLE;
        var relVelocity = velocity * WEIGHT_VELOCITY;
        var relDistance = distance * WEIGHT_DISTANCE;
        var relCollisions = collisions * WEIGHT_COLLISION;
        /*var relAngle = angle >= .02f ? 1 - (angle / 4) * WEIGHT_ANGLE : 1 * WEIGHT_ANGLE;
        var relVelocity = (1 - velocity) * WEIGHT_VELOCITY;
        var relDistance = 1 - ( distance / (spawnPoint.position - goalTransform.position).sqrMagnitude) * WEIGHT_DISTANCE;
        var relCollisions = collisions == 0 ? 1 * WEIGHT_COLLISION : 0 * WEIGHT_COLLISION;*/

        var fitness = relAngle + relVelocity + relDistance + relCollisions;

        return 1 / fitness;        
    }
}
