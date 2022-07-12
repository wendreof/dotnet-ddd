using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.User
{
    public class WhenRequestUser : BaseIntegration
    {
        private string Name { get; set; }
        private string Email { get; set; }

        [Fact(DisplayName = "Its Possibile To Create Crud User")]
        public async Task ItsPossibileToCreateCrudUser()
        {
            await AddToken();
            Name = Faker.Name.First();
            Email = Faker.Internet.Email();

            var userDto = new UserDtoCreate
            {
                Name = Name,
                Email = Email
            };

            //Post
            var response = await PostJsonAsync(userDto, $"{HostApi}users", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postRegistry = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(postRegistry);
            Assert.Equal(Name, postRegistry.Name);
            Assert.Equal(Email, postRegistry.Email);
            Assert.True(postRegistry.Id != default(Guid));

            //Get All
            response = await Client.GetAsync($"{HostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.True(list.Count() > 0);
            Assert.NotEmpty(list);
            Assert.Contains(list, x => x.Id == postRegistry.Id);

            //Put
            var updateUserDto = new UserDtoUpdate
            {
                Id = postRegistry.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto),
                Encoding.UTF8, "application/json");

            response = await Client.PutAsync($"{HostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var updatedRegistry = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(updatedRegistry);
            Assert.NotEqual(postRegistry.Name, updatedRegistry.Name);
            Assert.NotEqual(postRegistry.Email, updatedRegistry.Email);
            Assert.Equal(updateUserDto.Id, updatedRegistry.Id);

            //Get By Id
            response = await Client.GetAsync($"{HostApi}users/{updatedRegistry.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var getRegistry = JsonConvert.DeserializeObject<UserDto>(jsonResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(getRegistry);
            Assert.Equal(updatedRegistry.Id, getRegistry.Id);
            Assert.Equal(updatedRegistry.Name, getRegistry.Name);
            Assert.Equal(updatedRegistry.Email, getRegistry.Email);

            //Delete
            response = await Client.DeleteAsync($"{HostApi}users/{updatedRegistry.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await Client.GetAsync($"{HostApi}users/{updatedRegistry.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
