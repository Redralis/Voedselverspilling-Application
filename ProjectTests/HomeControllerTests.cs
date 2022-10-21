using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VoedselVerspillingApp.Controllers;
using Assert = Xunit.Assert;

namespace ProjectTests;

public class HomeControllerTests
{
    // US_01 - test if all meal boxes returned by method are not reserved
    [Fact]
    public void AvailableMealBoxes_Should_Return_NonReserved_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var employeeRepositoryMock = new Mock<IEmployeeRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, studentRepositoryMock.Object,
            employeeRepositoryMock.Object, productRepositoryMock.Object);
        
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var box2Time = new DateTime(2022, 11, 5, 13, 30, 0);

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Brood assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Brood box", CanteenId = 1, IsWarmMeal = false
            },
            new()
            {
                Id = 2, Name = "Warme maaltijd", City = "Breda",
                PickUpTime = box2Time, PickUpBy = box2Time.AddDays(2), IsEighteen = false, Price = 5.25m,
                MealType = "Warm eten", CanteenId = 2, IsWarmMeal = true
            }
        });

        // Act
        var result = sut.AvailableMealBoxes() as ViewResult;
        
        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(2, mealBoxesInModel!.Count);
        Assert.Null(mealBoxesInModel.First().StudentId);
        Assert.Null(mealBoxesInModel.Last().StudentId);
    }
    
    // US_01 - check if all meal boxes returned by method were reserved by student
    [Fact]
    public void ReservedMealBoxes_Should_Return_MealBoxes_Reserved_By_Student()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var studentRepositoryMock = new Mock<IStudentRepository>();
        var employeeRepositoryMock = new Mock<IEmployeeRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, studentRepositoryMock.Object,
            employeeRepositoryMock.Object, productRepositoryMock.Object);
        
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var box2Time = new DateTime(2022, 11, 5, 13, 30, 0);

        const string studentEmail = "lucas@email.com";

        studentRepositoryMock.Setup(studentRepo => studentRepo.GetStudent(studentEmail)).Returns(new Student
        {
            Id = 1, Name = "Lucas", DateOfBirth = "2003-01-27", StudentNr = "2191372",
            Email = "lucas@email.com", City = "Dordrecht", PhoneNr = "0692837263"
        });

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetReservedMealBoxes(1)).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Brood assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Brood box", CanteenId = 1, IsWarmMeal = false, StudentId = 1
            },
            new()
            {
                Id = 2, Name = "Warme maaltijd", City = "Breda",
                PickUpTime = box2Time, PickUpBy = box2Time.AddDays(2), IsEighteen = false, Price = 5.25m,
                MealType = "Warm eten", CanteenId = 2, IsWarmMeal = true, StudentId = 1
            }
        });

        // Act
        var result = sut.ReservedMealBoxes(studentEmail) as ViewResult;
        
        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(2, mealBoxesInModel!.Count);
        Assert.Equal(1, mealBoxesInModel.First().StudentId);
        Assert.Equal(1, mealBoxesInModel.Last().StudentId);
    }
}