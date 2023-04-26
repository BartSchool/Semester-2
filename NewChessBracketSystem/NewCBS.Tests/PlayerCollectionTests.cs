using NewCBS.Core;
using NewCBS.MockData;

namespace NewCBS.Tests;

public class PlayerCollectionTests
{
    //paramaterised tests

    [Fact]
    public void CantAddPlayerWithTheSameName()
    {
        //arrange
        PlayerCollection playerCollection = new PlayerCollection(new PlayerMockData());
        playerCollection.AddPlayer("bart");

        //act
        Action act = () => playerCollection.AddPlayer("bart");

        //assert
        Exception exception = Assert.Throws<Exception>(act);
        Assert.Equal("player allready exist", exception.Message);
    }
}