using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class StartAndEndOptimizedMutator: IMutator
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

        char newGen = genes[rand.Next(0, genes.Count)];
        //Lässt die erste und letzte stelle aus. Eigent sich für StartAndEndOptimzed
        int position = rand.Next(1, original.Length - 2);

        System.Text.StringBuilder builder = new System.Text.StringBuilder(original);
        builder[position] = newGen;

        return builder.ToString();
    }
}
