namespace Supply_Management_XYZ.Server.Utilities.Handlers;

public class ResponseHandler<TEntity>
{
    public int Code { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public TEntity? Data { get; set; }
}
