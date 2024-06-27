
using backend_challenge.Modules.refactor;

public class RefactorCalculatorTests
{
    [Fact]
    public void Calc_ReturnsExpectedResult()
    {
        // Arrange
        var refactor = new Calculator();
        var x = 5;
        var y = 10;
        var z = 20;
        int expectedResult = 150;

        // Act
        int actualResult = refactor.Calc(x, y, z);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void Calc_ReturnsExpectedResult2()
    {
        // Arrange
        var refactor = new Calculator();
        var x = 20;
        var y = 15;
        var z = 10;
        int expectedResult = 100;

        // Act
        int actualResult = refactor.Calc(x, y, z);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}