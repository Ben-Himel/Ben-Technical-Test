using System;
using Microsoft.AspNetCore.Identity;

namespace Ben_Technical_Test.Helper
{
    public class ArrayAuthentication
    {
        private string userFullName;

        public string UserFullName { get { return userFullName; } set { } }

        public bool Authenticate(string username, string password, string[][] authArray)
        {
            for (int i = 0; i < authArray.GetLength(0); i++)
            {
                if (authArray[i][1] == username && authArray[i][2] == password)
                {
                    userFullName= authArray[i][3];
                    return true; //match found
                }
                    
            }
            return false; // match not found


        }


    }
}
