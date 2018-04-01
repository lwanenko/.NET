using Accord.Neuro;
using Accord.Neuro.Learning;
using System;
using System.Collections.Generic;

namespace TestAccordNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double[][] train = { };
            double[][] test = { };


            var nn = new ActivationNetwork(new SigmoidFunction(0.1), 784, 10);
            var learn = new BackPropagationLearning(nn);

            nn.Randomize();

            Console.WriteLine("StartingLearning");

            for (int ep = 0; ep < 50; ep++)
            {
                var err = learn.RunEpoch(train, test);
            
                Console.WriteLine($"Epoch={ep}, Error={err}");
            }

            int count = 0, correct = 0;

            foreach (var v in test)
            {
            //    var n = nn.Compute(v.Image.Select(t => (double)t / 256.0).toArray());
            //    var z = n.MaxIndex();
            //    Console.WriteLine("{0} => {1}"), z, v.Label);
            //    if (z == v.Label) correct++;
            //    count++;
            }

            Console.WriteLine("Done, {0} of {1} correct ({2}%)", correct, count, (double)count * 100);
        }
    }
}
