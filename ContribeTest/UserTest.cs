using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreServer;

namespace ContribeTest {
  [TestClass]
  public class UserTest {
    [TestMethod]
    public void User() {
      Customers customers = Customers.Instance;

      //test
      Customer c1 = customers.GetCustomerByID("AAAA"); // New user should be created
      Customer c2 = customers.GetCustomerByID("aaaa"); // aaaa should be same as AAAA
      Customer c4 = customers.GetCustomerByID("bbbb"); // New user should be created
      Customer c5 = customers.GetCustomerByID(" bbbb  "); // " bbbb  " should be same as "bbbb"

      //validate
      Assert.IsNotNull(c1, "User 1 failed: User not created");
      Assert.AreEqual(c1, c2, "User 2 failed: user IDs should be case insensitive");
      Assert.AreNotEqual(c1, c4, "User 4 failed: Different UserID should result in different user objects");
      Assert.AreEqual(c4, c5, " User 5 failed: Whitespace in end and beginning of userID should not matter");
    }

    [TestMethod]
    [ExpectedException(typeof(Common.InfoException))]
    public void UserIDNull() {
      Customers customers = Customers.Instance;
      Customer c = customers.GetCustomerByID(null);
    }

    [TestMethod]
    [ExpectedException(typeof(Common.InfoException))]
    public void UserIDEmpty() {
      Customers customers = Customers.Instance;
      Customer c = customers.GetCustomerByID("    ");
    }
  }
}
