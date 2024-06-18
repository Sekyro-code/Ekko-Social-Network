//using AutoMapper;
//using Common.Api.DTOs.User;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Services.User.Api.Controllers;
//using Services.User.Api.Domain.Models;
//using Services.User.Api.Profiles;
//using Services.User.Api.Repositories.Interface;
//using Services.User.Api.Services.Interface;

//namespace Test.User.Api
//{
//    public class UserControllerUnitTest
//    {
//        [Fact]
//        public async Task SouldReturnUser()
//        {
//            // Arrange
//            var repositoryMock = new Mock<IUserRepository>();
//            repositoryMock.Setup(repo => repo.GetUserById(It.IsAny<Guid>()))
//                .ReturnsAsync((Guid userId) => new Services.User.Api.Domain.Models.User {

//                    Id = userId,
//                    UserName = "ExempleUserName",
//                    FirstName = "ExempleFirstName",
//                    LastName = "ExempleLastName",
//                    Birthday = "ExempleBirthday",
//                    Gender = true, 
//                    Email = "exemple@example.com",
//                    //Password = "ExemplePassword",
//                    Validate = true, 
//                    Notification = 42, 
//                    Biography = "ExempleBiography",
//                    Country = "ExempleCountry",
//                    PhoneNumber = "ExemplePhoneNumber",
//                    Picture = "ExemplePicture",
//                    Private = true, 
//                    CreatedAt = DateTime.UtcNow,
//                    Friendships = new List<UserRelation>(), 
//                    SentInvitations = new List<Invitation>(), 
//                    ReceivedInvitations = new List<Invitation>()

//                });

//            var mapperMock = new Mock<IMapper>();
//            mapperMock.Setup(mapper => mapper.Map<UserReadDto>(It.IsAny<Services.User.Api.Domain.Models.User>()))
//                .Returns((Services.User.Api.Domain.Models.User user) =>
//                {
//                    var config = new MapperConfiguration(cfg => cfg.AddProfile<UserProfile>());
//                    var mapper = config.CreateMapper();
//                    return mapper.Map<UserReadDto>(user);
//                });

//            var serviceMock = new Mock<IUserService>();
//            serviceMock.Setup(service => service.GetUserById(It.IsAny<Guid>()))
//                .Returns(async (Guid userId) =>
//                {
//                    var userFromRepository = await repositoryMock.Object.GetUserById(userId);

//                    var userReadDto = mapperMock.Object.Map<UserReadDto>(userFromRepository);

//                    return userReadDto;
//                });


//            var controller = new UserController(serviceMock.Object);
//            Guid userId = Guid.NewGuid();

//            // Act
//            var result = controller.GetUserById(userId);


//            // Assert
//            Assert.NotNull(result);
//            _ = Assert.IsType<Task<ActionResult<UserReadDto>>>(result);

//            var resultValue = await result;
//            Assert.IsType<ActionResult<UserReadDto>>(resultValue);

//        }
//    }
//}