using WalletApp.Application.Repositories;
using WalletApp.Application.Services;
using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService( IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _userRepository.GetUserByEmail(email);
    }

    public async Task CreateUser(User user)
    {
        await _userRepository.Insert(user);
    }

    public double CalculateDailyPoints()
    {
        var currentDate = DateTime.UtcNow;
        DateTime seasonStart = GetSeasonStartDate(currentDate);
    
        int dayOfSeason = (currentDate - seasonStart).Days + 1;
    
        switch (dayOfSeason)
        {
            case 1: return 2;
            case 2: return 3;
        }
    
        double previousPoints = 3;
        double prePreviousPoints = 2;
    
        for (int day = 3; day <= dayOfSeason; day++)
        {
            double newPoints = previousPoints + 0.6 * prePreviousPoints;
            prePreviousPoints = previousPoints;
            previousPoints = newPoints;
        }

        return Math.Round(previousPoints);
    }
    
    private static DateTime GetSeasonStartDate(DateTime currentDate)
    {
        int year = currentDate.Year;
        bool isSpring = currentDate.Month is >= 3 and < 6;
        bool isSummer = currentDate.Month is >= 6 and < 9;
        bool isAutumn = currentDate.Month is >= 9 and < 12;
        
        if (isSpring)
            return new DateTime(year, 3, 1);
        if (isSummer)
            return new DateTime(year, 6, 1);
        if (isAutumn)
            return new DateTime(year, 9, 1);
        
        return new DateTime(currentDate.Month is 1 or 2 ? year - 1 : year, 12, 1);
    }
}