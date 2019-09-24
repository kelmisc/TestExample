using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TestExample;
using TestExample.Controllers;
using TestExample.Service;
using UnitTest.HttpClientHandlers;
using Xunit;

namespace UnitTest
{
    public class UserControllerTest
    {
        [Fact]
        public async Task UserNotFoundShouldReturnNotFoundAsync()
        {
            //Arrange
            var httpClient = new HttpClient(new NotFoundHandler());
            httpClient.BaseAddress = new Uri("https://reqres.in/api/");
            var reqResTestService = new ReqResTestService(httpClient);
            var userController = new UsersController(reqResTestService);

            //Act
            var result = await userController.GetUser("3");

            //Assert
            Assert.True(result is NotFoundResult);
        }


    }
}
