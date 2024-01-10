namespace mobSite.Services;
public class TiersService
{
    private readonly TiersRepository _tiersRepository;

    public TiersService(TiersRepository tiersRepository)
    {
        _tiersRepository = tiersRepository;
    }
}