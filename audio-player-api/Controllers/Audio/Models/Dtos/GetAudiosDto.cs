namespace audio_player_api.Controllers.Audio.Models.Dtos
{
    public class GetAudiosDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AudioUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
