using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace GalaxyGuide
{
    public abstract class RuleValidator
    {
        protected RuleValidator Successor;

        public void SetSuccessor(RuleValidator successor)
        {
            this.Successor = successor;
        }

        public abstract void Validate(IEnumerable<RomanChart> romanNumber);
    }


    public class DLVRepetitionValidator : RuleValidator
    {
        public override void Validate(IEnumerable<RomanChart> romanNumber)
        {
            if (romanNumber.Count(x => x == RomanChart.V) > 1)
                throw new ArgumentException("Cannot contain more than one D, L and V!");

            if (romanNumber.Count(x => x == RomanChart.L) > 1)
                throw new ArgumentException("Cannot contain more than one D, L and V!");
            
            if (romanNumber.Count(x => x == RomanChart.D) > 1)
                throw new ArgumentException("Cannot contain more than one D, L and V!");
            
            if (Successor != null)
                Successor.Validate(romanNumber);
        }
    }

    public class MaxContinuousRepetitionValidator : RuleValidator
    {
        public int MaxRepetitionCount { get; private set; }

        public MaxContinuousRepetitionValidator(int maxRepetitionCount)
        {
            MaxRepetitionCount = maxRepetitionCount;
        }

        public override void Validate(IEnumerable<RomanChart> romanNumber)
        {
            var count = 1;
            var romanNumberArray = romanNumber as RomanChart[] ?? romanNumber.ToArray();
            for (var i = 0; i < romanNumberArray.Count() - 1; i++)
            {
                if (romanNumberArray[i] == romanNumberArray[i + 1])
                    count++;
                if (count > 3)
                    throw new ArgumentException("Cannot Contain more than three continuous repeated characters!");
            }

            if (Successor != null)
                Successor.Validate(romanNumber);
        }
    }

    public class SubtractionRuleValidator : RuleValidator
    {

        public override void Validate(IEnumerable<RomanChart> romanNumber)
        {
            var romanNumberArray = romanNumber as RomanChart[] ?? romanNumber.ToArray();
            for (var i = 0; i < romanNumberArray.Count(); i++)
            {
                if (i < romanNumberArray.Count() - 1)
                {
                    var value = (int) romanNumberArray[i+1] / (int) romanNumberArray[i];
                    if(value>10)
                        throw new ArgumentException("Subtraction rule violated!"); 
                }
            }

            if (Successor != null)
                Successor.Validate(romanNumber);
        }
    }

}