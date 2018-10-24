using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mutatotron = UnityEngine.Random;

public class MyMutator999 : IMutator
{
    static string[] abilities =
    {
        "fly","regenerate 2d6 health once per day", "read the minds of molluscs", "move at the speed of an old lady at the checkout counter",
        "die horribly from cancer", "speak with grass", "sense situationally inappropriate erections within 60ft", "do ninja stuff", "shoot lasers out of its eyes (1mW)",
        "explain the function of a Plumbus", "change the fabric of reality at will", "bring peace to the middle east", "prove their innocence in the Lindbergh kidnapping case"
    };

  
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
        System.Text.StringBuilder builder2 = new System.Text.StringBuilder();
        System.Text.StringBuilder builder3 = new System.Text.StringBuilder();
        for (int i = 0; i < original.Length; i++)
        {
            // mutate the first actions for driving backwards
            if ((original[i] == 'C' || original[i] == 'D') && i < 2)
            {
                builder3.Append('B');
            }
            else
            {
                builder3.Append(original[i]);
            }
        }

        String dontStearFirst = builder3.ToString();

        for (int i = 0; i < dontStearFirst.Length; i++)
        {
            // mutate the first actions for driving backwards
            if ( (dontStearFirst[i] == 'A' )&& i < 3 )
            {
                builder2.Append('B');
            }
            else
            {
                builder2.Append(dontStearFirst[i]);
            }
        }

        String allBackwards = builder2.ToString();


        for (int i = 0; i < allBackwards.Length-1; i++){
            if(allBackwards[i] == 'E'){
                builder.Append(getABCDRandom());
            } else {
                builder.Append(allBackwards[i]);
            }
        }
        builder.Append('E');
        //Debug.Log("MutatOTron blasted "+original+" into "+builder.ToString()+ ", it can now " + GetResult());
        return builder.ToString();
    }

    private string GetResult()
    {
        return abilities[Mutatotron.Range(0, abilities.Length)];
    }

    private char getABCDRandom(){

        int random = Mutatotron.Range(1, 5);

        switch (random){
            case 1:
                return 'A';
            case 2:
                return 'B';
            case 3:
                return 'C';
            case 4:
                return 'D';
            default:
                return 'C';
        }
        
        
    }
}
