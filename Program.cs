// This tells c# to import everything from system into the console
using System;

// This namespace is the parent of all the classes and objects inside of it . 
namespace MyProgram {

// This class represents all my classes and functions inside of it 
class program {


// this function is static 
// list class is expecting to tell it what kind of object is going to insde that list
    static List<row> ReadFile(string filePath) {
        // were creating a list that holds the rows
            // build this list thats gonna hold the rows when we call the function
            List<row>rows= new List<row>();
            // is going to read the context of the file line by line we want it to store temporarly
            string line ;

    // it can potentially throw an exception/ it potentially will not throw a file/ came to an exception that it wasnt reading my file
            try {
                // its creating a reader that takes the context that we provided and turn it into a stream of data that we can read
            // define the variable sr 
            // new keyword is used to create a new class
            StreamReader sr = new StreamReader(filePath);

            // while loop will read each line 
            // null if it doesnt find anything that it will return null
            while((line = sr.ReadLine()) != null){

                // it becomes an array of strings;
                // using single quote because were defining a character
                // it will split the number after it reaches the comma 
                string[] numbers = line.Split(',');

                // declaring variable to r
                row r = new row();

                // setting the value in the first instace 
                // firts and second number are being parsed into integers in order to call it
                r.firstNumber = int.Parse( numbers[0]);
                r.secondNumber = int.Parse(numbers[1]);

                // This is 
                rows.Add(r);
             }
            } 
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        // we dont need a finally block because we dont need the project to do anything after its done

        // the return is returning the amount of rows we have in the test.txt
                    return rows;
            
           
    }

     class row {
    //  creating a property that is specific to two key words .. what happens when user gets and set firs and second number
        public int firstNumber
        {
                get; set;
        }

        public int secondNumber 
        {
                get; set;
        }

 }

// Reversed row is a void function because were not returning anyhting
static void WriteFile(string filePath, List<row>row){
    
    // were taking the list of row and naming it reversedRow
    List<row>reversedRow = row;
    // this will reverse all of the elements in row
    reversedRow.Reverse();

    // this is saying that for each row in reversedRow i want you to console the first and second number
    foreach (row r in reversedRow)
    {
        // In order to display the first and second number we needed to do string interpolation
        Console.WriteLine($"{r.firstNumber},{r.secondNumber}");
    }
    try{
        // without using it wasnt saving the data to my filepath
        // its telling the compiler to dispose the streamWriter for me instead of inputing it manually
        // the using keyword dispose it from memory for streamwriter and streamReader
       using StreamWriter sw = new StreamWriter(filePath);

        foreach (row r in reversedRow)
        {
            sw.WriteLine($"{r.firstNumber},{r.secondNumber}");
        }
    } 
    // this is doing a catch all
    catch(Exception e)
     {
         Console.WriteLine(e.Message);
     }

}

    // Entry pOint of the c# program/ This is the Main door
        static void Main(string[] args) // args is where all of the arguments t is going to be stored
        {
              // were calling the text file
            List<row>rows = ReadFile("test.txt");
            
            foreach(row r in rows){
                Console.WriteLine($"{r.firstNumber},{r.secondNumber}");
            }
            
            // were displaying the reversed row
            WriteFile("test_expected_outcome.txt", rows);

        }
    }
}




