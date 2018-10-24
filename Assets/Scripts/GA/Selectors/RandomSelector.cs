using System;
using System.Collections;
using System.Collections.Generic;

public class RandomSelector : ISelector
{
    Random rand;
    public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
    {
        if (rand == null)
            rand = new Random();

        // Wie viele von der vorherigen Generation genommen werden  -> Zufall
        int count = rand.Next(0, parentGeneration.Individuals.Count);

        int individualsCount = parentGeneration.Individuals.Count;

        List<string> newGeneration = new List<string>();

        while (count-- != 0)
        {
            // Welche von der vorherigen Generation genommen werden     -> Zufall
            var firstIndividual = parentGeneration.Individuals[rand.Next(0, individualsCount)];
            var secondIndividual = parentGeneration.Individuals[rand.Next(0, individualsCount)];

            newGeneration.Add(firstIndividual.GeneSequence);
            newGeneration.Add(secondIndividual.GeneSequence);
        }

        // Sorgt dafür, dass die nicht ausdünnen und wir  doppelt so viele in der Liste haben (wie in dem Interface gefordert!)
        int diff = 2 * individualsCount - newGeneration.Count ;
        for (int i = 0; i < diff; ++i)
        {
            newGeneration.Add(newGeneration[rand.Next(0, newGeneration.Count)]);
        }

        return newGeneration;
    }
}
