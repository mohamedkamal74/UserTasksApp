namespace UserTasks.Models.ViewModels.Shared
{
    public class ObjectSourceResponse<T>
    {
        public ObjectSourceResponse(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public T Data { get; private set; }
        public string Message { get; private set; }
    }
}
