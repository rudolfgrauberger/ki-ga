using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class UniformRecombiner : IRecombiner
{
    public string Combine(string parentA, string parentB)
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder(parentA);

        //Jedes zweite Gen aus A wird durch das Gen aus B an derselben Stelle ersetzt
        for (int i = 1; i < parentA.Length; i += 2)
        {
            builder[i] = parentB[i];
        }

        return builder.ToString();
    }
}

