namespace Medyana.Data.Dto.Result
{
    public class Result
    {
        public bool Success { get; private set; }
        public object Root{ get; private set; }
        public string Message{ get; private set; }
        public ResultCodeEnum ResultCodeEnum{ get; private set; }

        public Result()
        {
            Success = false;
        }

        public Result(bool Success)
        {
            this.Success = Success;
        }

        protected Result(bool success, object root, string message, ResultCodeEnum resultCodeEnum)
        {
            this.Success = success;
            this.Root = root;
            this.Message = message;
            this.ResultCodeEnum = resultCodeEnum;
        }

        /*protected Result(bool success, ResultCodeEnum resultCodeEnum)
        {
            this.Success = success;
            this.ResultCodeEnum = resultCodeEnum;
        }*/
    }
}