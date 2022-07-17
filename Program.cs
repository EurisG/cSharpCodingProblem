using System;

namespace MyProgram
{
    class FileManipulation
    {
        public List<Row> ReadFile(string filePath)
        {

            List<Row> rows = new List<Row>();

            string line;

            try
            {

                FileStream file = new FileStream(filePath, FileMode.Open);
                using (StreamReader sr = new StreamReader(file))
                {
                    while ((line = sr.ReadLine()) != null)
                    {


                        string[] numbers = line.Split(',');


                        Row r = new Row();

                        r.firstNumber = int.Parse(numbers[0]);
                        r.secondNumber = int.Parse(numbers[1]);


                        rows.Add(r);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return rows;


        }

        public class Row
        {

            public int firstNumber
            {
                get; set;
            }

            public int secondNumber
            {
                get; set;
            }

        }


        public void WriteFile(string filePath, List<Row> row)
        {


            List<Row> reversedRow = row;

            try
            {

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    reversedRow.ForEach(row =>
                    {
                        sw.WriteLine($"{row.secondNumber},{row.firstNumber}");
                    });

                }

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


    }
    class Program
    {

        static void Main(string[] args) 
        {

            FileManipulation fm = new FileManipulation();
            List<FileManipulation.Row> rows = fm.ReadFile("test.txt");

            rows.ForEach(row =>
            {
                Console.WriteLine($"{row.secondNumber},{row.firstNumber}");
            });
            fm.WriteFile("test_expected_outcome.txt", rows);
        }
    }
}




