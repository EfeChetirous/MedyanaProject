namespace Medyana.Data.Dto.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(object Root, string Message): base(true, Root, Message, ResultCodeEnum.Success)
        {
        }
    }
}