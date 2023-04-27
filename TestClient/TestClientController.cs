using ClientAPI.Controllers;
using ClientAPI.Models;
using ClientAPI.Services;
using Moq;

namespace TestClient
{
    public class TestClientController
    {
        private readonly Mock<IClientService> clientService;
        public TestClientController()
        {
            clientService = new Mock<IClientService>();
        }

        [Fact]
        public void GetClientList_ClientList()
        {
            //arrange
            var clientList = GetClientsData();
            clientService.Setup(x => x.GetClientList()).Returns(clientList);
            var clientController = new ClientController(clientService.Object);

            //act
            var clientResult = clientController.ClientList();

            //assert
            Assert.NotNull(clientResult);
            Assert.Equal(GetClientsData().Count(), clientResult.Count());
            Assert.Equal(GetClientsData().ToString(), clientResult.ToString());
            Assert.True(clientList.Equals(clientResult));
        }

        [Fact]
        public void GetClientByID_Client()
        {
            //arrange
            var clientList = GetClientsData();
            clientService.Setup(x => x.GetClientById(2)).Returns(clientList[1]);
            var clientController = new ClientController(clientService.Object);

            //act
            var clientResult = clientController.GetClientById(2);

            //assert
            Assert.NotNull(clientResult);
            Assert.Equal(clientList[1].ClientId, clientResult.ClientId);
            Assert.True(clientList[1].ClientId == clientResult.ClientId);
        }

        [Theory]
        [InlineData("Jake Bream")]
        public void CheckClientExistOrNotByClientName_Client(string clientName)
        {
            //arrange
            var clientList = GetClientsData();
            clientService.Setup(x => x.GetClientList()).Returns(clientList);
            var clientController = new ClientController(clientService.Object);

            //act
            var clientResult = clientController.ClientList();
            var expectedClientName = clientResult.ToList()[0].ClientName;

            //assert
            Assert.Equal(clientName, expectedClientName);
        }

        [Fact]
        public void AddClient_Client()
        {
            //arrange
            var clientList = GetClientsData();
            clientService.Setup(x => x.AddClient(clientList[2])).Returns(clientList[2]);
            var clientController = new ClientController(clientService.Object);

            //act
            var clientResult = clientController.AddClient(clientList[2]);

            //assert
            Assert.NotNull(clientResult);
            Assert.Equal(clientList[2].ClientId, clientResult.ClientId);
            Assert.True(clientList[2].ClientId == clientResult.ClientId);
        }

        private List<Client> GetClientsData()
        {
            List<Client> clientsData = new List<Client>
            {
                new Client
                {
                    ClientId = 1,
                    ClientName = "Jake Bream",
                    EmailAddress = "jbream10@zimbio.com",
                    LiveDate = new DateTime(2022,5,12,16,32,23),
                },
                new Client
                {
                    ClientId = 2,
                    ClientName = "Lucine Casali",
                    EmailAddress = "lcasalik@patch.com",
                    LiveDate = new DateTime(2023,3,28,9,23,34),
                },
                new Client
                {
                    ClientId = 3,
                    ClientName = "Bev Pharaoh",
                    EmailAddress = "bpharaohz@tripod.com",
                    LiveDate = new DateTime(2020,1,10,14,23,54),
                }
            };
            return clientsData;
        }
    }
}