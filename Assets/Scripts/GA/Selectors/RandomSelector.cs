using System;
using System.Collections;
using System.Collections.Generic;

public class RandomSelector : ISelector
{
    Random r;
    public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
    {
        if (r == null) r = new Random();
        int sizeOfParentGeneration = r.Next(0, parentGeneration.Individuals.Count);
        int sizeOfIndividual = parentGeneration.Individuals.Count;
        List<string> c = new List<string>();
        while (sizeOfParentGeneration-- != 0)
        {
            var firstIndividual = parentGeneration.Individuals[r.Next(0, sizeOfIndividual)];
            var secondIndividual = parentGeneration.Individuals[r.Next(0, sizeOfIndividual)];
            c.Add(firstIndividual.GeneSequence);
            c.Add(secondIndividual.GeneSequence);
        }
        int diff = 2 * sizeOfIndividual - c.Count ;
        for (int i = 0; i < diff; ++i)
        {
            c.Add(c[r.Next(0, c.Count)]);
            c.Add(c[r.Next(0, c.Count)]);
        }
        return c;
    }
}
