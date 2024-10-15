

namespace chore_score.Repositories;

public class ChoresRepository
{
  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;


  internal List<Chore> GetChores()
  {
    string sql = "SELECT * FROM chores;";

    List<Chore> chores = _db.Query<Chore>(sql).ToList();
    return chores;
  }

  internal Chore GetChoreById(int choreId)
  {
    string sql = "SELECT * FROM chores WHERE id = @choreId";

    Chore chore = _db.Query<Chore>(sql, new { choreId }).FirstOrDefault();
    return chore;
  }

  internal Chore CreateChore(Chore choreData)
  {
    string sql = @"
        INSERT INTO
        chores (name, description, isComplete)
        VALUES (@name, @description, @isCompleted);
        SELECT * FROM chores WHERE id = LAST_INSERT_ID";

    Chore chore = _db.Query<Chore>(sql, choreData).FirstOrDefault();
    return chore;
  }
}