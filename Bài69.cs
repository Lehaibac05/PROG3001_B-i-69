using System;
using System.IO;
using System.Linq;

class FileOperations
{
    public static int CountLines(string filePath)
    {
        int lineCount = 0;
        using (var reader = new StreamReader(filePath))
        {
            while (reader.ReadLine() != null)
            {
                lineCount++;
            }
        }
        return lineCount;
    }

    public static int CountCharacterOccurrences(string filePath, char character)
    {
        int count = 0;
        using (var reader = new StreamReader(filePath))
        {
            int ch;
            while ((ch = reader.Read()) != -1)
            {
                if ((char)ch == character)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public static int CountWords(string filePath)
    {
        int wordCount = 0;
        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                wordCount += line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }
        return wordCount;
    }
}


class Utf8FileOperations
{
    public static void ReadAndWriteUtf8(string inputFilePath, string outputFilePath)
    {
        string content;
        using (var reader = new StreamReader(inputFilePath, System.Text.Encoding.UTF8))
        {
            content = reader.ReadToEnd();
        }

        using (var writer = new StreamWriter(outputFilePath, false, System.Text.Encoding.UTF8))
        {
            writer.Write(content);
        }
    }
}


class Utf16FileOperations
{
    public static void ReadAndWriteUtf16(string inputFilePath, string outputFilePath)
    {
        string content;
        using (var reader = new StreamReader(inputFilePath, System.Text.Encoding.Unicode))
        {
            content = reader.ReadToEnd();
        }

        using (var writer = new StreamWriter(outputFilePath, false, System.Text.Encoding.Unicode))
        {
            writer.Write(content);
        }
    }
}



class BinaryFileOperations
{
    public static void Write2DArrayToBinaryFile(double[,] array, string filePath)
    {
        using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            writer.Write(rows);
            writer.Write(cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write(array[i, j]);
                }
            }
        }
    }

    public static double[,] Read2DArrayFromBinaryFile(string filePath)
    {
        using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int rows = reader.ReadInt32();
            int cols = reader.ReadInt32();
            double[,] array = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = reader.ReadDouble();
                }
            }

            return array;
        }
    }
}
