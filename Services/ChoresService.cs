

namespace chore_score.Services;

public class ChoresService
{

  public ChoresService(ChoresRepository choresRepository)
  {
    _choresRepository = choresRepository;
  }
  private readonly ChoresRepository _choresRepository;

  internal List<Chore> GetChores()
  {
    List<Chore> chores = _choresRepository.GetChores();
    return chores;
  }

  internal Chore GetChoreById(int choreId)
  {
    Chore chore = _choresRepository.GetChoreById(choreId);

    if (chore == null)
    {
      throw new Exception($"Invalid id: {choreId}");
    }

    return chore;
  }

  internal Chore CreateChore(Chore choreData)
  {
    Chore chore = _choresRepository.CreateChore(choreData);
    return chore;
  }
}