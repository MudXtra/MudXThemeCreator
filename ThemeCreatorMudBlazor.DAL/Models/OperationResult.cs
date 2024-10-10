namespace ThemeCreatorMudBlazor.DAL.Models
{
	public class OperationResult<T>(bool success, string message, T? data, string details)
	{
		public bool Success { get; set; } = success;
		public string Message { get; set; } = message;
		public string Details { get; set; } = details;
		public T? Data { get; set; } = data;

		public static OperationResult<T> SuccessResult(T data, string message = "Success", string details = "Success")
		{
			return new OperationResult<T>(true, message, data, details);
		}

		public static OperationResult<T> FailureResult(string message, string details)
		{
			return new OperationResult<T>(false, message, default, details);
		}
	}
}
