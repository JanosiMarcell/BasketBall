namespace BasketballXd.Models
{
    public record CreatePlayerDto(string Name, int Height, int Weight, DateTime? CreatedTime,Guid Id);
    public record UpdatePlayerDto(string Name, int Height, int Weight, DateTime? CreatedTime);




}
