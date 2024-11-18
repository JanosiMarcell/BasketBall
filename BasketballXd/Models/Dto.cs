namespace BasketballXd.Models
{
    public record CreatePlayerDto(string Name, int Height, int Weight, DateTime? CreatedTime,Guid Id);
    public record UpdatePlayerDto(string Name, int Height, int Weight, DateTime? CreatedTime);
    
    public record CreateMatchDto(DateTime? SubIn, Guid PlayerId, int FGA, int FGM, int Foul, DateTime CreatedTime);
    public record UpdateMatchDto(DateTime SubOut, int FGA, int FGM,int Foul, DateTime UpdatedTime, Guid Id);




}
