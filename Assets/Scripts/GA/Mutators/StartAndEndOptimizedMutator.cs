using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mutatotron = UnityEngine.Random;

public class StartAndEndOptimizedMutator : IMutator
{
    static string[] abilities =
    {
        "fly","regenerate 2d6 health once per day", "read the minds of molluscs", "move at the speed of an old lady at the checkout counter",
        "die horribly from cancer", "speak with grass", "sense situationally inappropriate erections within 60ft", "do ninja stuff", "shoot lasers out of its eyes (1mW)",
        "explain the function of a Plumbus", "change the fabric of reality at will", "bring peace to the middle east", "prove their innocence in the Lindbergh kidnapping case"
    };

    private float mutationRate = .1f;
    private List<char> geneIDs;

    public void AssignGene(char ID)
    {
        if (geneIDs == null)
            geneIDs = new List<char>();
        geneIDs.Add(ID);
    }

    public string Mutate(string original)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        for(int i=0; i< original.Length; i++)
        {
            // Da wir wollen, dass das Auto nachher stehen bleibt, mutieren wir alle Gene, außer
            // - es ist das letzte und bereits 'E' (= stehen bleiben) oder
            // - es ist das erste und bereits 'B' (= rückwärts fahren)

            if (Mutatotron.value < mutationRate && 
                !(i == (original.Length -1) && original[i] == 'E') &&       // <- Stehen bleiben
                !(i == 0) && original[i] == 'B')                            // <- Rückwärts fahren
                builder.Append(geneIDs[Mutatotron.Range(0, geneIDs.Count)]);
            else
                builder.Append(original[i]);
        }

        return builder.ToString();
    }

    private string GetResult()
    {
        return abilities[Mutatotron.Range(0, abilities.Length)];
    }
}
