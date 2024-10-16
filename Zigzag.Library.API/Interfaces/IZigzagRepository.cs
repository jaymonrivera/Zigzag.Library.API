namespace Zigzag.Library.API.Interfaces;

public interface IZigzagRepository
{
    string Error { get; }
    bool HasError { get; }
    void AppendError(string message);
}
