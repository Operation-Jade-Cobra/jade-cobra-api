using jade.cobra.Domain;
using jade.cobra.Domain.Catalog;
namespace jade.cobra.Domain.Tests;

[TestClass]
public class RatingTests
{
    [TestMethod]
    public void Can_Create_New_Rating()
    {
        var item = new Item("Name", "Description", "Brand", 10.99m);
        var rating = new Rating(1, "Mike", "Great fit!");
        
        item.AddRating(rating);
        Assert.AreEqual(rating, item.Ratings[0]);
        //Assert.AreEqual(1, rating.Stars);
        //Assert.AreEqual("Mike", rating.UserName);
        //Assert.AreEqual("Great fit!", rating.Review);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Rating_With_Invalid_Stars(){
        var rating = new Rating(0, "Mike", "Great fit!");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Rating_With_Invalid_User_Name(){
        var rating = new Rating(1, null!, "Great fit!");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Rating_With_Invalid_Review(){
        var rating = new Rating(1, "Mike", null!);
    }
}
