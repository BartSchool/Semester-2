using NewCBS.Core;
using NewCBS.MockData;

namespace NewCBS.Tests;

public class PlayerCollectionTests
{
    PlayerGenerator PG = new PlayerGenerator();
    //paramaterised tests

    [Fact]
    public void CantAddPlayerWithTheSameName()
    {
        //arrange
        PlayerCollection playerCollection = new PlayerCollection(new PlayerMockData());
        string name = "bart";
        playerCollection.AddPlayer(name);

        //act
        Action act = () => playerCollection.AddPlayer(name);

        //assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("player allready exist", exception.Message);
    }
}