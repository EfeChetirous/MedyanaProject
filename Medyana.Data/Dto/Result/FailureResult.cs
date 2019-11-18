namespace Medyana.Data.Dto.Result
{
    public class FailureResult:Result
    {
        public FailureResult():base(false, null, "An unexpected error occurred while resuming the transaction!", ResultCodeEnum.Failure)
        {
            
        }
        
        public FailureResult(string message):base(false, null, message, ResultCodeEnum.Failure)
        {
            
        }

        public FailureResult(ResultCodeEnum resultCodeEnum):base(false, null, "An unexpected error occurred while resuming the transaction!", resultCodeEnum)
        {
            
        }
    }
}