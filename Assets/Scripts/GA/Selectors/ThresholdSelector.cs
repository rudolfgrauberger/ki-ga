using System;
using System.Collections;
using System.Collections.Generic;

public class ThresholdSelector : ISelector
{
    Random rand;
    const float THRESHOLD_PERCENT= .05f;
    public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
    {
        if (rand == null)
            rand = new Random();

        // Filters the last THRESHOLD_PERCENT bad individuals out
        int badThresholdIndex = (int)(parentGeneration.Individuals.Count * THRESHOLD_PERCENT);
        float threshouldValue = parentGeneration.Individuals[parentGeneration.Individuals.Count - badThresholdIndex].Fitness;

        var selectedIndividums = parentGeneration.Individuals.FindAll(x => x.fitnessValue > threshouldValue);

        int diff = parentGeneration.Individuals.Count - selectedIndividums.Count;

        for (int i = 0; i < diff; ++i)
        {
            int index = rand.Next(0, selectedIndividums.Count);
            selectedIndividums.Add(selectedIndividums[index]);
        }

        List<string> newGeneration = new List<string>();

        selectedIndividums.ForEach(x => newGeneration.Add(x.GeneSequence));
        selectedIndividums.ForEach(x => newGeneration.Add(x.GeneSequence));

        return newGeneration;
    }
}
