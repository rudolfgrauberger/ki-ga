using System;
using System.Collections;
using System.Collections.Generic;

public class NinetyFivePercentTerminator : ITerminator
{
    public bool JudgementDay(GenerationDB.Generation generation)
    {
        return generation.Fittest.Fitness >= .034f;
    }
}
