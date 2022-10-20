namespace audio_player_api.Utils
{
    public class PaginationParams
    {
        // 最大只能50，超過就會被限制為50
        private readonly int _maxPageSize = 50;
        // 預設是10
        private int _pageSize = 10;

        public int Page { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _maxPageSize) ? _maxPageSize : value;
        }
    }
}
