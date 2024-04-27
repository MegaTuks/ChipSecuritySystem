using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Color defaultStart = Color.Blue;
            Color defaultEnd = Color.Green;
            List<ColorChip> chipList = new List<ColorChip>();
            BagGenerator bag;
            Console.Clear();
            Console.WriteLine("Application Start");
            Console.WriteLine("Input Chip Generation type");
            Console.WriteLine("0 Default Test Case");
            Console.WriteLine("1 Test Case2 ");
            Console.WriteLine("Any other number X - Random Generated Bag of size X");
            Console.WriteLine("Non int numeric value - Default Test Case");
            int caseInput;
            if (!int.TryParse(Console.ReadLine(), out caseInput)) {
                Console.WriteLine("Using Default test case");
                bag = new BagGenerator(0);
            }
            else
            {
                Console.WriteLine("Using Random chip generation of size: " + caseInput);
                bag = new BagGenerator(caseInput);
            }
            chipList = bag.GetBattleChips();
            bag.PrintBag();
            CombinationSolver solver  = new CombinationSolver(defaultStart, defaultEnd, chipList);
            solver.CombinationSolverOptions(null, chipList, new List<ColorChip>(),0);
            solver.PrintSolution();
            Console.ReadLine();
        }
    }
}
