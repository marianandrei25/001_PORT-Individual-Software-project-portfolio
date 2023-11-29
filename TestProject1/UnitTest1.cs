using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using adad;
using System.IO;
using DDD_PROJECT;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        

        [TestMethod]
        public void ConstructorTest()

        {

            // Arrange 

            int testid = 21;

            string testUsername = "DAMIAN";



            // Act 

            Username user = new Username(testid, testUsername);



            // Assert 

            Assert.AreEqual(testid, user.id);

            Assert.AreEqual(testUsername, user.username);

        }

        [TestMethod]

        public void ConstructorTest2()

        {

            // Arrange  

            string testType = "Student";

            string testUsername = "DAMIAN";

            // Act  

            Register user = new Register(testUsername, testType);

            // Assert  

            Assert.AreEqual(testType, user.type);

            Assert.AreEqual(testUsername, user.userName);

        }
      
        
        [TestMethod]
        public void ReadFile_Success()
        {
            // Arrange
            string filePath = "C:\\Users\\672484\\Desktop\\regSTUDENTS.txt"; // Replace with the path to your test file
            string expectedContent = "TestForReadfile";
            // Act
            string actualContent;
            using (StreamReader tw = File.OpenText(filePath))
            {
                actualContent =  tw.ReadToEnd();
            }

            // Assert
            Assert.AreEqual(expectedContent, actualContent);
        }

    }
}
