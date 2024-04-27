using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class CombinationSolver
    {
        Color StartColor {  get; set; }
        Color EndColor { get; set; }
        List<ColorChip> OriginalBag { get; set; }
        Dictionary<int, List<ColorChip>> possibleCombinations = new Dictionary<int, List<ColorChip>>();
       List<ColorChip> MaxCombination = new List<ColorChip>();

        public CombinationSolver(Color startColor, Color endColor, List<ColorChip> originalBag)
        {
            StartColor = startColor;
            EndColor = endColor;
            OriginalBag = originalBag;
        }

        public Boolean HasValidChips(Color? A,List<ColorChip> currentSelection)
        {
            ;
            if(currentSelection.Where(c => A == c.StartColor || A == c.EndColor).Count() > 0)
            {
                return true;
            }
            return false;
        }

        public List<ColorChip> GetPossibleOptionsBag(Color? a, List<ColorChip> currentSelection)
        {
           return currentSelection.Where(c => a == c.StartColor || a == c.EndColor).ToList();
     
        }
        public ColorChip FlipChip(ColorChip A)
        {
            Color Start = A.EndColor;
            Color End = A.StartColor;
            return new ColorChip(Start,End);
        }

        public void PrintSolution()
        {
            if(MaxCombination.Count == 0)
            {
                Console.WriteLine(Constants.ErrorMessage);
                return;
            }
            for (int i = 0; i < MaxCombination.Count; i++)
            {
                Console.Write(" [ " + MaxCombination[i].ToString() + " ] ");
            }
            Console.WriteLine(" *Reminder chips can be flipped, solution displays chip in the order they connect.");
            Console.WriteLine(" ");
            Console.WriteLine("List of solutions ");
            PrintOtherSolutions();
        }

        public void PrintOtherSolutions()
        {   foreach(KeyValuePair<int,List<ColorChip>> val in possibleCombinations) {
                Console.Write("Length: " + val.Key.ToString());
                for (int i = 0; i < val.Value.Count ; i++)
                {
                    Console.Write(" [ " + val.Value[i].ToString() + " ] ");
                }
                Console.WriteLine();

            }

        }

        public void CombinationSolverOptions(Color? left, List<ColorChip> availableChips, List<ColorChip> usedChips,int lvl)
        {
            List<ColorChip> levelUsed = usedChips.ToList();
            List<ColorChip> levelAvailable = availableChips.ToList();
            
            if (left == EndColor ) {
                //finish recursive checking
                if(possibleCombinations.ContainsKey(usedChips.Count))
                    possibleCombinations[usedChips.Count()] = usedChips.ToList();
                else
                    possibleCombinations.Add(usedChips.Count(), usedChips.ToList());
                if (MaxCombination.Count < usedChips.Count)
                    MaxCombination = usedChips.ToList();
            }
            if (left == null)
            {
                left = StartColor;
            }
            Color levelColor = (Color) left;
            bool hasValid = HasValidChips(left, availableChips) && HasValidChips(EndColor, availableChips);
            if (hasValid) {
                    List<ColorChip> possibleBag = GetPossibleOptionsBag(left, availableChips);
                    for(int i = 0; i < possibleBag.Count;i++)
                    {
                        ColorChip current = possibleBag[i];
                        usedChips = levelUsed.ToList();
                        availableChips = levelAvailable.ToList();
                        if(levelColor == current.StartColor)
                        {
                            usedChips.Add(current);
                            availableChips.Remove(current);
                            CombinationSolverOptions(current.EndColor, availableChips, usedChips, lvl+1);
                        } else if(levelColor == current.EndColor)
                        {
                            availableChips.Remove(current);
                            current = FlipChip(current);
                            usedChips.Add(current);
                            CombinationSolverOptions(current.EndColor, availableChips, usedChips, lvl+1);
                        }
                    }
                    
            }

        }
     }
}

