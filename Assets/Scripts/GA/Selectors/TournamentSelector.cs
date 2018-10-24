using System;
using System.Collections;
using System.Collections.Generic;

public class TournamentSelector : ISelector
{
    Random rand;
    public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
    {
        if (rand == null)
            rand = new Random();

        int count = parentGeneration.Individuals.Count / 2;
        List<string> newGeneration = new List<string>();

        while (count != 0)
        {
            int lastIndex = parentGeneration.Individuals.Count;
            var firstIndividual = parentGeneration.Individuals[rand.Next(0, lastIndex)];
            var secondIndividual = parentGeneration.Individuals[rand.Next(0, lastIndex)];

            if (firstIndividual.Fitness > secondIndividual.Fitness)
            {
                parentGeneration.Individuals.Remove(secondIndividual);
            }
            else
            {
                parentGeneration.Individuals.Remove(firstIndividual);
            }

            count--;
        }



        parentGeneration.Individuals.ForEach(x => newGeneration.Add(x.GeneSequence));
        parentGeneration.Individuals.ForEach(x => newGeneration.Add(x.GeneSequence));
        parentGeneration.Individuals.ForEach(x => newGeneration.Add(x.GeneSequence));
        parentGeneration.Individuals.ForEach(x => newGeneration.Add(x.GeneSequence));

        return newGeneration;
    }
}
