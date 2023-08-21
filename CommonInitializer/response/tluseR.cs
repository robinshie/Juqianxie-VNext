namespace CommonInitializer
{
    public class ResultResponse<T>
    {
        public int count { get; set; }
        public IEnumerable<T> datas { get; set; }
        public ResultResponse()
        {
            datas = new List<T>();
        }

    }
}
