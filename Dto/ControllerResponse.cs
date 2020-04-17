
namespace StatsApi.Dto
{
    public class ControllerResponse<T>
    {
        public T data { get; set; }

        public bool success { get; set; } = true;

        public string message { get; set; } = null;
    }
}