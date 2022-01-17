namespace VedasPortal.Repository.Interface
{
    interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
