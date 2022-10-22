using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Moq;
using VoedselVerspillingApp.Controllers;
using VoedselVerspillingApp.ViewModels;
using Assert = Xunit.Assert;

namespace ProjectTests;

public class HomeControllerTests
{
    // US_01_1 - test if all meal boxes returned by method are not reserved
    [Fact]
    public void AvailableMealBoxes_Should_Return_NonReserved_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);

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

    // US_01_2 - check if all meal boxes returned by method were reserved by student
    [Fact]
    public void ReservedMealBoxes_Should_Return_MealBoxes_Reserved_By_Student()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var studentRepositoryMock = new Mock<IStudentRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, studentRepositoryMock.Object,
            null!, null!);

        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var box2Time = new DateTime(2022, 11, 5, 13, 30, 0);
        const string studentEmail = "lucas@email.com";

        studentRepositoryMock.Setup(studentRepo => studentRepo.GetStudentByEmail(studentEmail)).Returns(new Student
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

    // US_02 doesn't have tests since the two lists an employee gets are simply the available meals, but sorted
    // and displayed in two separate sections of their available meals page.

    // US_03_1 an employee should be able to create meal boxes
    [Fact]
    public void Employee_Should_Be_Able_To_Create_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, productRepositoryMock.Object);

        const int productId = 1;
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var model = new MealBoxViewModel
        {
            ProductIds = new List<int> { productId }
        };

        productRepositoryMock.Setup(productRepo => productRepo.GetProduct(productId)).Returns(new Product
        {
            Id = 1, Name = "Wit brood", IsAlcoholic = false,
            Photo =
                "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
        });

        var mealBox = new MealBox()
        {
            Id = 1, Name = "Brood assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Brood box", IsWarmMeal = false
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Brood assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Brood box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.CreateMealBox(mealBox, model);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(1, mealBoxesInModel!.First().Id);
        Assert.Equal("Brood assortiment", mealBoxesInModel!.First().Name);
    }

    // US_03_2 an employee should be able to edit meal boxes
    [Fact]
    public void Employee_Should_Be_Able_To_Edit_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, productRepositoryMock.Object);

        const int productId = 1;
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var model = new MealBoxViewModel
        {
            ProductIds = new List<int> { productId }
        };

        productRepositoryMock.Setup(productRepo => productRepo.GetProduct(productId)).Returns(new Product
        {
            Id = 1, Name = "Wit brood", IsAlcoholic = false,
            Photo =
                "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
        });

        var mealBox = new MealBox()
        {
            Id = 1, Name = "Snoep assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Snoep box", CanteenId = 1, IsWarmMeal = false
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Snoep assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Snoep box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.EditMealBox(mealBox, "edit", model);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(22.50m, mealBoxesInModel!.First().Price);
        Assert.Equal("Snoep assortiment", mealBoxesInModel!.First().Name);
    }

    // US_03_3 an employee should be able to delete meal boxes
    [Fact]
    public void Employee_Should_Be_Able_To_Delete_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);

        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var mealBox = new MealBox()
        {
            Id = 1, Name = "Snoep assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Snoep box", CanteenId = 1, IsWarmMeal = false
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>());

        // Act
        sut.EditMealBox(mealBox, "delete", null!);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Empty(mealBoxesInModel!);
    }

    // US_03_4 an employee should not be able to edit reserved meal boxes
    [Fact]
    public void Employee_Should_Not_Be_Able_To_Edit_Reserved_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, productRepositoryMock.Object);

        const int productId = 1;
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var model = new MealBoxViewModel
        {
            ProductIds = new List<int> { productId }
        };

        productRepositoryMock.Setup(productRepo => productRepo.GetProduct(productId)).Returns(new Product
        {
            Id = 1, Name = "Wit brood", IsAlcoholic = false,
            Photo =
                "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
        });

        var mealBox = new MealBox()
        {
            Id = 1, Name = "Brood assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Brood box", CanteenId = 2, IsWarmMeal = true, StudentId = 1
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Snoep assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Snoep box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.EditMealBox(mealBox, "edit", model);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(22.50m, mealBoxesInModel!.First().Price);
        Assert.Equal("Snoep assortiment", mealBoxesInModel!.First().Name);
    }

    // US_03_5 an employee should not be able to delete reserved meal boxes
    [Fact]
    public void Employee_Should_Not_Be_Able_To_Delete_Reserved_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);

        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var mealBox = new MealBox
        {
            Id = 1, Name = "Snoep assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Snoep box", CanteenId = 1, IsWarmMeal = false, StudentId = 1
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Snoep assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Snoep box", CanteenId = 1, IsWarmMeal = false, StudentId = 1
            }
        });

        // Act
        sut.EditMealBox(mealBox, "delete", null!);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(22.50m, mealBoxesInModel!.First().Price);
        Assert.Equal("Snoep assortiment", mealBoxesInModel!.First().Name);
    }

    // US_04_1 meal boxes should automatically become 18+ when they contain an alcoholic product
    [Fact]
    public void Created_MealBoxes_Should_Become_Eighteen_Plus_When_At_Least_One_Product_Is_Alcoholic()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, productRepositoryMock.Object);

        const int productId = 7;
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var model = new MealBoxViewModel
        {
            ProductIds = new List<int> { productId }
        };

        productRepositoryMock.Setup(productRepo => productRepo.GetProduct(productId)).Returns(new Product
        {
            Id = 7, Name = "Bier", IsAlcoholic = true,
            Photo =
                "https://images.pexels.com/photos/1552630/pexels-photo-1552630.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
        });

        var mealBox = new MealBox()
        {
            Id = 1, Name = "Alcohol Arrangement", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Alcohol box", CanteenId = 1, IsWarmMeal = false
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Alcohol Arrangement", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = true, Price = 22.50m,
                MealType = "Alcohol box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.CreateMealBox(mealBox, model);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(1, mealBoxesInModel!.First().Id);
        Assert.True(mealBoxesInModel!.First().IsEighteen);
    }

    // US_04_2 an underage student should not be able to reserve a meal box if it is eighteen plus
    [Fact]
    public void Student_Under_Eighteen_Should_Not_Be_Able_To_Reserve_Eighteen_Plus_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var tempDataProvider = Mock.Of<ITempDataProvider>();
        var tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
        var tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);
        sut.TempData = tempData;

        const int mealBoxId = 1;
        const string studentEmail = "lucas@email.com";

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.ReserveMealBox(mealBoxId, studentEmail)).Returns(
            "Student is te jong voor deze maaltijdbox!");

        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Alcohol Arrangement", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = true, Price = 22.50m,
                MealType = "Alcohol box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.AvailableMealBoxes(mealBoxId, studentEmail);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal("Student is te jong voor deze maaltijdbox!", result.TempData["Message"]);
        Assert.Single(mealBoxesInModel!);
    }

    // US_05_1 a student should be able to reserve meal boxes
    [Fact]
    public void Student_Should_Be_Able_To_Reserve_MealBoxes()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var tempDataProvider = Mock.Of<ITempDataProvider>();
        var tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
        var tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);
        sut.TempData = tempData;

        const int mealBoxId = 1;
        const string studentEmail = "lucas@email.com";

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.ReserveMealBox(mealBoxId, studentEmail)).Returns(
            "Maaltijdbox gereserveerd!");
        
        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>());

        // Act
        sut.AvailableMealBoxes(mealBoxId, studentEmail);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal("Maaltijdbox gereserveerd!", result.TempData["Message"]);
        Assert.Empty(mealBoxesInModel!);
    }
    
    // US_05_2 a student should not be able to reserve more than 1 meal box per pickup day
    [Fact]
    public void Student_Should_Not_Be_Able_To_Reserve_More_Than_One_MealBox_Per_Pickup_Day()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var tempDataProvider = Mock.Of<ITempDataProvider>();
        var tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
        var tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);
        sut.TempData = tempData;

        const int mealBoxId = 1;
        const string studentEmail = "lucas@email.com";

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.ReserveMealBox(mealBoxId, studentEmail)).Returns(
            "Student heeft al een maaltijdbox gereserveerd op deze dag!");

        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Alcohol Arrangement", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = true, Price = 22.50m,
                MealType = "Alcohol box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.AvailableMealBoxes(mealBoxId, studentEmail);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal("Student heeft al een maaltijdbox gereserveerd op deze dag!", result.TempData["Message"]);
        Assert.Single(mealBoxesInModel!);
    }
    
    // US_06 doesn't have tests since the only criteria is that the products are displayed on the details page.
    
    // US_07_1 a student should not be able to reserve a meal box which is already reserved
    [Fact]
    public void Student_Should_Not_Be_Able_To_Reserve_A_Reserved_MealBox()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();

        var tempDataProvider = Mock.Of<ITempDataProvider>();
        var tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
        var tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, null!);
        sut.TempData = tempData;

        const int mealBoxId = 1;
        const string studentEmail = "lucas@email.com";

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.ReserveMealBox(mealBoxId, studentEmail)).Returns(
            "Maaltijdbox is al gereserveerd!");
        
        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>());

        // Act
        sut.AvailableMealBoxes(mealBoxId, studentEmail);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal("Maaltijdbox is al gereserveerd!", result.TempData["Message"]);
        Assert.Empty(mealBoxesInModel!);
    }
    
    // US_09_1 an employee should be able to create warm meal boxes if their location serves them
    [Fact]
    public void Employee_Should_Be_Able_To_Create_Warm_MealBoxes_If_Location_Serves_Them()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, productRepositoryMock.Object);

        const int productId = 1;
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var model = new MealBoxViewModel
        {
            ProductIds = new List<int> { productId }
        };

        productRepositoryMock.Setup(productRepo => productRepo.GetProduct(productId)).Returns(new Product
        {
            Id = 1, Name = "Wit brood", IsAlcoholic = false,
            Photo =
                "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
        });

        // Since location serves warm meals, the IsWarmMeal select box is available to choose a value.
        var mealBox = new MealBox()
        {
            Id = 1, Name = "Brood assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Brood box", IsWarmMeal = true
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Brood assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Brood box", CanteenId = 1, IsWarmMeal = true
            }
        });

        // Act
        sut.CreateMealBox(mealBox, model);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(1, mealBoxesInModel!.First().Id);
        Assert.True( mealBoxesInModel!.First().IsWarmMeal);
    }
    
    // US_09_1 an employee should be able to create warm meal boxes if their location serves them
    [Fact]
    public void Employee_Should_Not_Be_Able_To_Create_Warm_MealBoxes_If_Location_Does_Not_Serve_Them()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();
        var mealBoxRepositoryMock = new Mock<IMealBoxRepository>();
        var productRepositoryMock = new Mock<IProductRepository>();

        var sut = new HomeController(loggerMock.Object, mealBoxRepositoryMock.Object, null!,
            null!, productRepositoryMock.Object);

        const int productId = 1;
        var box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        var model = new MealBoxViewModel
        {
            ProductIds = new List<int> { productId }
        };

        productRepositoryMock.Setup(productRepo => productRepo.GetProduct(productId)).Returns(new Product
        {
            Id = 1, Name = "Wit brood", IsAlcoholic = false,
            Photo =
                "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
        });

        // Since location doesn't serve warm meals, the IsWarmMeal select box is unavailable to choose a value and
        // defaults to false.
        var mealBox = new MealBox()
        {
            Id = 1, Name = "Brood assortiment", City = "Breda",
            PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
            MealType = "Brood box", IsWarmMeal = false
        };

        mealBoxRepositoryMock.Setup(mealBoxRepo => mealBoxRepo.GetAvailableMealBoxes()).Returns(new List<MealBox>
        {
            new()
            {
                Id = 1, Name = "Brood assortiment", City = "Breda",
                PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                MealType = "Brood box", CanteenId = 1, IsWarmMeal = false
            }
        });

        // Act
        sut.CreateMealBox(mealBox, model);
        var result = sut.AvailableMealBoxes() as ViewResult;

        // Assert
        var mealBoxesInModel = result!.Model as List<MealBox>;
        Assert.Equal(1, mealBoxesInModel!.First().Id);
        Assert.False( mealBoxesInModel!.First().IsWarmMeal);
    }
}