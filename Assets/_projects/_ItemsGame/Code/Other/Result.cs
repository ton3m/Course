namespace ItemsGame
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailed => IsSuccess == false;
        
        public string Message { get; }

        public Result(bool isSuccess, string message)
        {
            Message = message;
            IsSuccess = isSuccess;
        }

        public static Result Success => new Result(true, "Success.");

        public static Result Failed(string error = "Error") => new Result(false, error);
    }
}