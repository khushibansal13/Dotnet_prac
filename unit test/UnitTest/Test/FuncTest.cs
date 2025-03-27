using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest.Test
{
    public static class FuncTest
    {
        public static void Func_ReturnsPikachuIfZero_ReturnString()
        {
            try
            {
                //Arrange - getting variables, classes, fn
                int num = 0;
                Func func = new Func();

                //Act - Execute the function
                string result = func.RetursPikachuIfZero(num);

                //Assert - what is the expected result check for that
                if (result == "Pikachu")
                {
                    Console.WriteLine("Test Passed : Func_ReturnsPikachuIfZero_ReturnString");
                }
                else
                {
                    Console.WriteLine("Test Failed : Func_ReturnsPikachuIfZero_ReturnString");
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");   
                throw;
            }
        }
    }
}