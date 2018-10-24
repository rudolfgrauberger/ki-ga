using System;
using System.Collections.Generic;

public class RandomMutator : IMutator
{
    private List<char> genes;
    private Random rand;

    public void AssignGene(char ID)
    {
        if (genes == null)
        {
            genes = new List<char>();
        }
        genes.Add(ID);
    }

    public string Mutate(string original)
    {
        if (rand == null)
            rand = new Random();

        char newGen= genes[rand.Next(0, genes.Count)];
        //Wählt aus dem gesamten string eine Stelle aus
        int position = rand.Next(0, original.Length - 1);

        System.Text.StringBuilder builder = new System.Text.StringBuilder(original);
        builder[position] = newGen;

        return builder.ToString();
    }
}