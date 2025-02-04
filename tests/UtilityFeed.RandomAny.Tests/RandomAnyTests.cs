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
			int length = 30;

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
			int length = 30;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.UpperCase);

			// Assert
			Assert.Equal(result.ToUpper(), result);
		}

		[Fact]
		public void RandomString_SnakeCase_ReturnsSnakeCaseString()
		{
			// Arrange
			int length = 30;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.SnakeCase);

			// Assert
			Assert.Contains("_", result);
		}

		[Fact]
		public void RandomString_KebabCase_ReturnsKebabCaseString()
		{
			// Arrange
			int length = 30;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.KebabCase);

			// Assert
			Assert.Contains("-", result);
		}

		[Fact]
		public void RandomString_LowerCase_ReturnsLowerCaseString()
		{
			// Arrange
			int length = 30;

			// Act
			string result = RandomAny.RandomString(length, caseType: Case.LowerCase);

			// Assert
			Assert.Equal(result.ToLower(), result);
		}

		[Fact]
		public void RandomString_PascalCase_ReturnsPascalCaseString()
		{
			int length = 30;

			string result = RandomAny.RandomString(length, caseType: Case.PascalCase);
			
			Assert.True(char.IsUpper(result[0]));
		}

		[Fact]
		public void RandomString_CamelCase_ReturnsCamelCaseString()
		{
			// Arrange
			int length = 30;

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
			int endInt = 30;

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

		[Fact]
		public void RandomDate_DefaultParameters_ReturnsDateBetweenMinAndMax()
		{
			// Arrange
			DateTime minDate = DateTime.MinValue;
			DateTime maxDate = DateTime.MaxValue;

			// Act
			DateTime result = RandomAny.RandomDate();

			// Assert
			Assert.InRange(result, minDate, maxDate);
		}

		[Fact]
		public void RandomDate_CustomStartDate_ReturnsDateBetweenStartAndMax()
		{
			// Arrange
			DateTime startDate = new DateTime(2020, 1, 1);
			DateTime maxDate = DateTime.MaxValue;

			// Act
			DateTime result = RandomAny.RandomDate(startDate: startDate);

			// Assert
			Assert.InRange(result, startDate, maxDate);
		}

		[Fact]
		public void RandomDate_CustomEndDate_ReturnsDateBetweenMinAndEnd()
		{
			// Arrange
			DateTime minDate = DateTime.MinValue;
			DateTime endDate = new DateTime(2023, 12, 31);

			// Act
			DateTime result = RandomAny.RandomDate(endDate: endDate);

			// Assert
			Assert.InRange(result, minDate, endDate);
		}

		[Fact]
		public void RandomDate_CustomStartAndEndDate_ReturnsDateBetweenStartAndEnd()
		{
			// Arrange
			DateTime startDate = new DateTime(2020, 1, 1);
			DateTime endDate = new DateTime(2023, 12, 31);

			// Act
			DateTime result = RandomAny.RandomDate(startDate, endDate);

			// Assert
			Assert.InRange(result, startDate, endDate);
		}

		[Fact]
		public void RandomDate_StartDateGreaterThanEndDate_ThrowsArgumentException()
		{
			// Arrange
			DateTime startDate = new DateTime(2023, 12, 31);
			DateTime endDate = new DateTime(2020, 1, 1);

			// Act & Assert
			Assert.Throws<ArgumentException>(() => RandomAny.RandomDate(startDate, endDate));
		}
	}
}