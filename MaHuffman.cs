using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HuffmanNode
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
    }

    class Huffman2_4
    { 
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string input = "ABCDEEDC";
            Dictionary<char, int> frequencies = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            HuffmanNode root = BuildHuffmanTree(frequencies);

            Console.WriteLine("Huffman Codes:");
            PrintHuffmanCodes(root, "");
        }

        public static HuffmanNode BuildHuffmanTree(Dictionary<char, int> frequencies)
        {
            var trees = frequencies.Select(x => new HuffmanNode { Character = x.Key, Frequency = x.Value }).ToList();

            while (trees.Count > 1)
            {
                trees = trees.OrderBy(x => x.Frequency).ToList();

                var firstNode = trees[0];
                var secondNode = trees[1];

                var mergedNode = new HuffmanNode
                {
                    Frequency = firstNode.Frequency + secondNode.Frequency,
                    Left = firstNode,
                    Right = secondNode
                };

                trees.Remove(firstNode);
                trees.Remove(secondNode);
                trees.Add(mergedNode);
            }

            return trees.FirstOrDefault();
        }

        public static void PrintHuffmanCodes(HuffmanNode node, string code)
        {
            if (node == null)
            {
                return;
            }

            if (node.Left == null && node.Right == null)
            {
                Console.WriteLine($"{node.Character}: {code}");
            }

            PrintHuffmanCodes(node.Left, code + "0");
            PrintHuffmanCodes(node.Right, code + "1");
        }
    }
}
