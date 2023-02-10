namespace Ben_Technical_Test.Helper
{
    public static class CSVReader
    {
        public static string[][] ReadCSVRaw(string fileName)
        {
            //using jagged array to adapt to inconsitancies in raw data
            string[][] values;
            try
            {
                //all lines stored into 1st array to reduce file access time while processing
                string[] fileLines = File.ReadAllLines(fileName);
                values = new string[fileLines.Length][];

                for (int i = 0; i < fileLines.Length; i++)
                {
                    values[i] = fileLines[i].Split(',');
                }
                return values;

            }
            catch (FileNotFoundException fx)
            {
                Console.WriteLine(fx.Message);
                values = new string[0][];
                return values;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                values = new string[0][];
                return values;
            }
        }

        //TODO, display method in works
        static public void displayCSV(string fileName) 
        {
            string[][] displayArray = new string[fileName.Length][];
            ReadCSVRaw(fileName);

        }


            //TODO could run a second method to convert raw CSV data into specific expected data types.
            //TODO write method to remove Garbage data and null rows.
            
            

        


    }
}
