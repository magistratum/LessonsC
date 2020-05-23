using System;
using System.IO;

namespace Lesson6_HW
{
    public class BinaryRW
    {
        public void Binar()
        {
            int i;
            const int arrayLength = 1000;

            // Create random data to write to the stream.
            Random randomGenerator = new Random();
            double[] dataArray = new double[arrayLength];
            for (i = 0; i < arrayLength; i++)
            {
                dataArray[i] = 100.1 * randomGenerator.NextDouble();
            }
            FileStream fs = new FileStream("datbin.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (BinaryWriter binWriter =
                new BinaryWriter(fs))
            {
                // Write the data to the stream.
                Console.WriteLine("Writing data to the stream.");
                for (i = 0; i < arrayLength; i++)
                {
                    binWriter.Write(dataArray[i]);
                }

                // Create a reader using the stream from the writer.
                using (BinaryReader binReader =
                    new BinaryReader(binWriter.BaseStream))
                {
                    try
                    {
                        // Return to the beginning of the stream.
                        binReader.BaseStream.Position = 0;

                        // Read and verify the data.
                        Console.WriteLine("Verifying the written data.");
                        double[] arr = new double[arrayLength];
                        for (i = 0; i < arrayLength; i++)
                        {
                            //arr[i] = binReader.ReadDouble();
                            if ((arr[i] = binReader.ReadDouble()) != dataArray[i])
                            {
                                Console.WriteLine("Error writing data.");
                                break;
                            }
                        }
                        foreach (double v in arr)
                            Console.WriteLine(v);
                        Console.WriteLine("The data was written " +
                            "and verified.");
                    }
                    catch (EndOfStreamException e)
                    {
                        Console.WriteLine("Error writing data: {0}.",
                            e.GetType().Name);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}