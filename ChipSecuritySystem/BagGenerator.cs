using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class BagGenerator
    {
        public List<ColorChip> BattleChips = new List<ColorChip>();

        public BagGenerator(int type)
        {
            switch(type)
            {
                case 0://TestCase
                    GenerateTestCase();
                    break;
                case 1://TestCase
                    GenerateTestCase2();
                    break;
                default:
                    RandomGeneration(type);
                    break;
            }
        }
        public List<ColorChip> GetBattleChips() {  return BattleChips; }

        public void PrintBag()
        {
            for (int i = 0; i < BattleChips.Count; i++)
            {
                Console.Write("[ " + BattleChips[i].ToString() + " ] ");
            }
            Console.WriteLine();
        }

        public void GenerateTestCase() {
            BattleChips.Add(new ColorChip(Color.Blue, Color.Yellow));
            BattleChips.Add(new ColorChip(Color.Red, Color.Green));
            BattleChips.Add(new ColorChip(Color.Yellow, Color.Red));
            BattleChips.Add(new ColorChip(Color.Orange, Color.Purple));
        }
        public void GenerateTestCase2()
        {
            BattleChips.Add(new ColorChip(Color.Red, Color.Green));
            BattleChips.Add(new ColorChip(Color.Yellow, Color.Red));
            BattleChips.Add(new ColorChip(Color.Blue, Color.Green));
            BattleChips.Add(new ColorChip(Color.Yellow, Color.Yellow));
            BattleChips.Add(new ColorChip(Color.Red, Color.Green));
        }

        public void RandomGeneration( int size)
        {
            Random random = new Random();
            for(int i = 0; i < size; i++)
            {
                Color firstColor = (Color)random.Next(0, 6);
                Color secondColor = (Color)random.Next(0, 6);
                ColorChip chip = new ColorChip(firstColor, secondColor);
                BattleChips.Add(chip);
            }
        }
    }
}
