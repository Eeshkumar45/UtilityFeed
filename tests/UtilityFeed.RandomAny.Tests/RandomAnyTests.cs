using UtilityFeed;
using UtilityFeed.RandomAny.Enums;
namespace UtilityFeed.RandomAny.Tests
{
	public class RandomAnyTests
	{
		[Fact]
		public void RandomString_ValidLength_ReturnsStringOfExpectedLength()
		{
			// Arrange
			int length = 10;

			// Act
			string result = RandomAny.RandomString(length);

			// Assert
			Assert.Equal(length, result.Length);
		}

		[Fact]
		public void RandomString_LengthZero_ThrowsArgumentException()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => RandomAny.RandomString(0));
		}

		[Fact]
		public void RandomString_EmptyCharset_ThrowsArgumentException()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => RandomAny.RandomString(10, ""));
		}

		[Fact]
		public void RandomString_UpperCase_ReturnsUpperCaseString()
		{
			// Arrange
			int length = 10;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.UpperCase);

			// Assert
			Assert.Equal(result.ToUpper(), result);
		}

		[Fact]
		public void RandomString_LowerCase_ReturnsLowerCaseString()
		{
			// Arrange
			int length = 10;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.LowerCase);

			// Assert
			Assert.Equal(result.ToLower(), result);
		}

		[Fact]
		public void RandomString_PascalCase_ReturnsPascalCaseString()
		{
			int length = 15;

			string result = RandomAny.RandomString(length, caseType: Case.PascalCase);
			
			Assert.True(char.IsUpper(result[0]));
		}

		[Fact]
		public void RandomString_CamelCase_ReturnsCamelCaseString()
		{
			// Arrange
			int length = 15;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.CamelCase);

			// Assert
			Assert.Equal(char.ToLower(result[0]) + result.Substring(1), result);
		}

		[Fact]
		public void RandomInt_ValidRange_ReturnsIntInRange()
		{
			// Arrange
			int startInt = 1;
			int endInt = 10;

			// Act
			int result = RandomAny.RandomInt(startInt, endInt);

			// Assert
			Assert.InRange(result, startInt, endInt);
		}

		[Fact]
		public void RandomInt_StartGreaterThanEnd_ThrowsArgumentException()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(() => RandomAny.RandomInt(10, 5));
		}

		[Fact]
		public void RandomInt_DefaultRange_ReturnsIntInDefaultRange()
		{
			// Act
			int result = RandomAny.RandomInt();

			// Assert
			Assert.InRange(result, int.MinValue, int.MaxValue);
		}
	}
}