using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class UniformRecombiner : IRecombiner
{
    public string Combine(string parentA, string parentB)
    {

        string invA;
        string invB;

        Random rand = new Random();
        if(rand.Next(0,2)<1)
        {
            invA = parentA;
            invB = parentB;
        }
        else
        {
            invA = parentB;
            invB = parentA;
        }

        System.Text.StringBuilder builder = new System.Text.StringBuilder(invA);

        //Jedes zweite Gen aus A wird durch das Gen aus B an derselben Stelle ersetzt
        for (int i = 1; i < invA.Length; i += 2)
        {
            builder[i] = invB[i];
        }

        return builder.ToString();
    }
}

