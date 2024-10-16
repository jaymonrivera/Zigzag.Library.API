using Microsoft.EntityFrameworkCore;

namespace Zigzag.Library.API.Infra.Data;

public abstract class BaseRepository<T> where T : DbContext
{
    protected readonly T _dbContext;

    protected BaseRepository(T dbContext)
    {
        _dbContext = dbContext;
    }

    public string Error { get; private set; } = string.Empty;
    public bool HasError => !string.IsNullOrEmpty(Error);

    public void AppendError(string errorMessage)
    {
        if (HasError)
            Error += "\n";

        Error += errorMessage;
    }
}