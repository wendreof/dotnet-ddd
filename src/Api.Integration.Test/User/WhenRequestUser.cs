using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [Fact(DisplayName = "Its Possibile ToCreate Crud User")]
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

            var stringContent = new StringContent(JsonConvert.SerializeObject(userDto));
        }
    }
}
