using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GA.Selectors
{
    class MySelector999 : ISelector
    {
        private Random rand;
        private List<char> genes;

        /// <summary>
        /// Ist das hier nur die Liste, die an den Recombinder übergeben wird, oder ist das die komplette neue generation
        /// Add 
        /// </summary>
        /// <param name="parentGeneration"></param>
        /// <returns></returns>
        public List<string> SelectFromGeneration(GenerationDB.Generation parentGeneration)
        {
            if (rand == null) rand = new Random();
            if ( genes == null)
            {
                genes  = new List<char>();
                genes.Add('A');
                genes.Add('B');
                genes.Add('C');
                genes.Add('D');
                genes.Add('E');
            }

            parentGeneration.Sort();
            List<string> superAwesomeNewGen = new List<string>();
            int max = parentGeneration.Individuals.Count;
            int cut = (int)(max * 0.60);
            int delta = max - cut;

            int count = 0;
            for (int i = 0; i < cut; i++)
            {
                Individual a = parentGeneration.individuals[i];
                superAwesomeNewGen.Add(a.GeneSequence);
                Individual b = parentGeneration.Individuals[(i + 1) % parentGeneration.Individuals.Count];
                superAwesomeNewGen.Add(b.GeneSequence);

            }
            for (int i = 0; i < delta; i++)
            {
                int len = parentGeneration.Individuals[0].geneSequence.Length;
                Individual a = GenRandInd(len);
                Individual b = GenRandInd(len);
                superAwesomeNewGen.Add(a.GeneSequence);
                superAwesomeNewGen.Add(b.GeneSequence);
            }
            return superAwesomeNewGen;
        }

        private Individual GenRandInd(int size)
        {
            Individual ind = new Individual();
            System.Text.StringBuilder builder = new System.Text.StringBuilder(size);
            int max = 4;
            for ( int i = 0; i < size; i++)
            {
                builder.Append(genes[rand.Next(0, max)]);
            }
            ind.GeneSequence = builder.ToString();
            return ind;
        }
    }
}
